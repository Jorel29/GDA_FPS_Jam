using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiActiveHomingFishWeaponController : MonoBehaviour
{
    public Transform lockedTarget;
    public bool trackerActive;

    void Start()
    {
        trackerActive = false;
    }

    void Update()
    {
        Debug.Log("Controller Tracker: " + trackerActive);
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
