// Date   : 21.01.2018 19:44
// Project: Kajam #3
// Author : bradur

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager main;

    [SerializeField]
    private Transform playerTransform;

    private void Awake()
    {
        main = this;
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }

    void Start () {

    }

    void Update () {
    
    }
}
