using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SemiActiveHomingFish_PrimaryProjectile : BaseBullet
{
    public float homingStrength = 0;
    public float homingRate = 1;
    public float maximumHomingSpeed = 5;
    public float acceleration = 0.5f;
    public Transform lockedTarget;
    private List<Transform> targets;

    public override void Start()
    {
        base.Start();
        lockedTarget = FormController.Instance.currentForm.GetComponent<SemiActiveHomingFishWeaponController>().lockedTarget;
        targets = FormController.Instance.currentForm.GetComponent<LockAreaFOV>().targetable;
    }

    private void Update()
    {
        

        if (homingStrength < 1)
        {
            homingStrength += homingRate * Time.deltaTime;
        }
        
        _rigidbody.AddForce(transform.forward * acceleration, ForceMode.Acceleration);
        
    }

    private void FixedUpdate()
    {
        //check if target is lost
        lockedTarget = FormController.Instance.currentForm.GetComponent<SemiActiveHomingFishWeaponController>().lockedTarget;
        if (lockedTarget == null)
        {
            return;
        }
        //apply homing force if tracker is active
        if (FormController.Instance.currentForm.GetComponent<SemiActiveHomingFishWeaponController>().trackerActive)
        {
            ApplyHomingForce();
        }else if (targets.Count > 0)
        {
            lockedTarget = targets.First();
            ApplyHomingForce();
        }
        else
        {
            lockedTarget= null;
        }
    }

    void ApplyHomingForce()
    {
        Vector3 homingDirection = (lockedTarget.position - transform.position).normalized;


        _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity.normalized, homingDirection, homingStrength) * _rigidbody.velocity.magnitude;

        //_rigidbody.AddForce(homingDirection * homingStrength, ForceMode.Impulse);
        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, maximumHomingSpeed);
        transform.forward = _rigidbody.velocity.normalized;

    }


}
