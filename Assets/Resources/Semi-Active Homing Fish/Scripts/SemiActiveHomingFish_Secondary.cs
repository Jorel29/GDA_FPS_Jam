using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Forms/SemiActiveHomingFish_Secondary Form")]
public class SemiActiveHomingFish_Secondary : BaseForm
{
    [Header("Form Specific Data")]
    public GameObject _bullet;
    private bool trackerState;
    //FormAction() is called each time the form "shoots".
    public override void FormAction(float context)
    {
        base.FormAction(-1);
        //checks the Controller's "trackerActive" bool variable, and sets it to true or false
        if (FormController.Instance.currentForm.GetComponent<SemiActiveHomingFishWeaponController>().trackerActive == false)
        {
            FormController.Instance.currentForm.GetComponent<SemiActiveHomingFishWeaponController>().trackerActive = true;
        }
        else
        {
            FormController.Instance.currentForm.GetComponent<SemiActiveHomingFishWeaponController>().trackerActive = false;
        }

        //Spawn bullet prefab at weapon's barrel position
        var bullet = Instantiate(_bullet, FormController.Instance.currentForm.barrelSpawn.position, Quaternion.identity);
        SpawnedGarbageController.Instance.AddAsChild(bullet);
        // Raycast into world from camera position + direction, if target found, set bullet target position to that point, else, bullet direction mimics player camera.
        // This allows us to shoot these projectile bullets from the gun rather than the center of the screen to get the desired appearance
        // If the weapon were hitscan, we could skip this and just add tracers from the gun to the desired destination

        bullet.GetComponent<BaseHitscan>().SetTargetDirection(Camera.main.transform.forward);


    }
}
