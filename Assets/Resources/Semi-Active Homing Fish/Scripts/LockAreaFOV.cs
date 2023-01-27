using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using System.Linq;

//aquired and modified from tutorial https://github.com/SebLague/Field-of-View/blob/master/Episode%2001/Scripts/FieldOfView.cs
//which was made from Sebastian Lague
//modifed by Jorel Huerto
public class LockAreaFOV : MonoBehaviour
{
    public GameObject _bullet;
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]
    public List<Transform> targetable = new List<Transform>();

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        targetable.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            //Debug.Log(targetsInViewRadius[i].name);  
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                Damageable damageable = target.gameObject.GetComponent<Damageable>();

                // Check if target is a Damageable
                if (damageable != null)
                {
                    // If it is, add to targetable list
                    targetable.Add(target);
                    Debug.Log("TARGET LOCKED:" + targetable.First().name);
                    
                }
            }
        }
    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}