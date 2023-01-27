using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SemiActiveHomingFishWeaponController : MonoBehaviour
{
    public GameObject _bullet;
    public Transform lockedTarget;
    public bool trackerActive;
    private List<Transform> targets;
    void Start()
    {
        trackerActive = false;
        targets = FormController.Instance.currentForm.GetComponent<LockAreaFOV>().targetable;
    }

    void Update()
    {
        if (trackerActive)
        {
            StartCoroutine("PingTarget", 100f);
        }
        else
        {
            StopCoroutine("PingTarget");
        }
        Debug.Log("Controller Tracker: " + trackerActive);
        if(targets.Count > 0)
        {
            Debug.Log(targets.First().name);
        }
    }
    IEnumerator PingTarget(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay*Time.deltaTime);
            Vector3 targetDir = Camera.main.transform.forward;
            if (targets.Count > 0)
            {
                targetDir = (targets.First().position - FormController.Instance.currentForm.barrelSpawn.position).normalized;
            }

            //Spawn bullet prefab at weapon's barrel position
            var bullet = Instantiate(_bullet, FormController.Instance.currentForm.barrelSpawn.position, Quaternion.identity);
            SpawnedGarbageController.Instance.AddAsChild(bullet);
            // Raycast into world from camera position + direction, if target found, set bullet target position to that point, else, bullet direction mimics player camera.
            // This allows us to shoot these projectile bullets from the gun rather than the center of the screen to get the desired appearance
            // If the weapon were hitscan, we could skip this and just add tracers from the gun to the desired destination

            bullet.GetComponent<BaseHitscan>().SetTargetDirection(targetDir);
        }
    }
    public void ToggleTrackerState()
    {
        if (trackerActive == false) 
        {
            trackerActive = true;
        }
        else
        {
            trackerActive = false;
        }
    }
}
