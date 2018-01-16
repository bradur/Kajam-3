// Date   : 15.01.2018 21:21
// Project: Kajam #3
// Author : bradur

using UnityEngine;
using System.Collections;

public class FollowTargetPosition : MonoBehaviour {

    [SerializeField]
    private Transform target;

    void Start () {
    
    }

    void Update () {
        transform.position = target.transform.position;
    }
}
