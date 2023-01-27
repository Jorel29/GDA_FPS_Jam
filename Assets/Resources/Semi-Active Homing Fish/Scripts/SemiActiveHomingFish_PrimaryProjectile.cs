using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiActiveHomingFish_PrimaryProjectile : BaseBullet
{
    public float homingStrength = 0;
    public float homingRate = 1;
    public float maximumHomingSpeed = 5;
    public Transform lockedTarget;

    public override void Start()
    {
        base.Start();
        lockedTarget = FormController.Instance.currentForm.GetComponent<SemiActiveHomingFishWeaponController>().lockedTarget;
    }

    private void Update()
    {
        

        if (homingStrength < 1)
        {
            homingStrength += homingRate * Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        lockedTarget = FormController.Instance.currentForm.GetComponent<SemiActiveHomingFishWeaponController>().lockedTarget;
        if (lockedTarget == null)
        {
            return;
        }

        ApplyHomingForce();
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
