using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using UnityEngine;

[CreateAssetMenu(menuName = "Forms/SemiActiveHomingFish_Secondary Form")]
public class SemiActiveHomingFish_Secondary : BaseForm
{
    [Header("Form Specific Data")]
    public GameObject _bullet;
    private bool trackerActive;
    private List<Transform> targetable;

    //FormAction() is called each time the form "shoots".
    public override void FormAction(float context)
    {
        base.FormAction(-1);
        //tracker Toggle
        FormController.Instance.currentForm.GetComponent<SemiActiveHomingFishWeaponController>().ToggleTrackerState();
        /*trackerActive = FormController.Instance.currentForm.GetComponent<SemiActiveHomingFishWeaponController>().trackerActive;
        targetable = FormController.Instance.currentForm.GetComponent<LockAreaFOV>().targetable;
        Debug.Log(targetable.Count);
        Debug.Log("TrackerState:" + trackerActive);
        //toggle tracker on or off
        
        Vector3 targetDir = Camera.main.transform.forward;
        if (targetable.Count > 0)
        {
            targetDir = (targetable.First().position - FormController.Instance.currentForm.barrelSpawn.position).normalized;
        }
        
        //Spawn bullet prefab at weapon's barrel position
        var bullet = Instantiate(_bullet, FormController.Instance.currentForm.barrelSpawn.position, Quaternion.identity);
        SpawnedGarbageController.Instance.AddAsChild(bullet);
        // Raycast into world from camera position + direction, if target found, set bullet target position to that point, else, bullet direction mimics player camera.
        // This allows us to shoot these projectile bullets from the gun rather than the center of the screen to get the desired appearance
        // If the weapon were hitscan, we could skip this and just add tracers from the gun to the desired destination

        bullet.GetComponent<BaseHitscan>().SetTargetDirection(targetDir);
        */

    }
}
