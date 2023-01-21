using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAHFishWeaponController : MonoBehaviour
{
    public Transform homingTarget;
    //following code
    //modified from Sebasian Lague -
    //Field of View Visualization
    //https://www.youtube.com/watch?v=rQG9aUWarwE
    Rigidbody weaponRigidbody;
    Camera viewCamera;

    void Start()
    {
        
        weaponRigidbody = GetComponent<Rigidbody>();
        viewCamera = PlayerController.Instance.GetComponent<Camera>();

    }

    void Update()
    {
        Vector3 mouseLook = viewCamera.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
    }

}
