// Date   : 15.01.2018 22:26
// Project: Kajam #3
// Author : bradur

using UnityEngine;
using System.Collections;

public class IndependentRigidbodyDrag : MonoBehaviour
{

    [SerializeField]
    [Range(0f, 1f)]
    private float factor = 0.9f;

    [SerializeField]
    private bool dragX = true;

    [SerializeField]
    private bool dragY = true;

    [SerializeField]
    private bool dragZ = true;

    private bool drag = false;

    private Rigidbody rigidbody3D;

    void Start()
    {
        rigidbody3D = GetComponent<Rigidbody>();
    }

    public void EnableDrag()
    {
        drag = true;
    }

    public void DisableDrag()
    {
        drag = false;
    }

    void Update()
    {
        if (drag)
        {
            Vector3 velocity = rigidbody3D.velocity;
            if (dragX)
            {
                velocity.x *= factor;
            }
            if (dragY)
            {
                velocity.y *= factor;
            }
            if (dragZ)
            {
                velocity.z *= factor;
            }
            if (dragX || dragY || dragZ)
            {
                rigidbody3D.velocity = velocity;
            }
        }
    }
}
