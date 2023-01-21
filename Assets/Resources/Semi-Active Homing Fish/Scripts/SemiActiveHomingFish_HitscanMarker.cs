using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiActiveHomingFish_HitscanMarker : BaseHitscan
{
    public override void ProcessDamage()
    {
        Damageable damageable = hitInfo.transform.gameObject.GetComponent<Damageable>();

        // Check if target is a Damageable
        if (damageable != null)
        {
            // If it does, damage the target
            damageable.ProcessDamage(damage);
            FormController.Instance.currentForm.GetComponent<SemiActiveHomingFishWeaponController>().lockedTarget = damageable.transform;
        }

        HitInteractable hitable = hitInfo.transform.gameObject.GetComponent<HitInteractable>();

        // Check if target is a hitable
        if (hitable != null)
        {
            // If it does, damage the target
            hitable.ProcessHit();
        }
    }
}
