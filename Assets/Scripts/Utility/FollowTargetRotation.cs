// Date   : 15.01.2018 21:24
// Project: Kajam #3
// Author : bradur

using UnityEngine;
using System.Collections;

public class FollowTargetRotation : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private bool followX = true;
    [SerializeField]
    private bool followY = true;
    [SerializeField]
    private bool followZ = true;


    void Start () {
    
    }

    void Update () {
        Vector3 oldRotation = transform.localEulerAngles;
        Vector3 newRotation = target.transform.localEulerAngles;
        if (!followX)
        {
            newRotation.x = oldRotation.x;
        }
        if (!followY)
        {
            newRotation.y = oldRotation.y;
        }
        if (!followZ)
        {
            newRotation.z = oldRotation.z;
        }
        transform.localEulerAngles = newRotation;
    }
}
