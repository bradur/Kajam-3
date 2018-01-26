// Date   : #CREATIONDATE#
// Project: #PROJECTNAME#
// Author : #AUTHOR#

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController3D : MonoBehaviour
{

    [SerializeField]
    private CharacterCrouch characterCrouch;
    private Rigidbody rigidbody3D;

    [SerializeField]
    [Range(1.5f, 100f)]
    private float sprintSpeed = 15f;

    [SerializeField]
    [Range(1f, 20f)]
    private float forwardSpeed = 11f;

    [SerializeField]
    [Range(0.1f, 20f)]
    private float backWardSpeed = 6f;

    [SerializeField]
    [Range(0.1f, 20f)]
    private float strafeSpeed = 8f;

    [SerializeField]
    private IndependentRigidbodyDrag drag;

    [SerializeField]
    [Range(0f, 1f)]
    private float startDragging = 0.5f;

    /*[SerializeField]
    private ForceMode moveForceMode;*/

    [SerializeField]
    [Range(0f, 100f)]
    private float gravityStrength = 5f;

    [SerializeField]
    [Range(0f, 25f)]
    private float jumpSpeed = 5f;

    private CapsuleCollider capsuleCollider;
    private bool grounded = false;

    private Vector3 playerDirection = Vector3.zero;

    [SerializeField]
    private LayerMask groundMask;

    void Start()
    {
        rigidbody3D = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(
            capsuleCollider.bounds.center,
            new Vector3(
                capsuleCollider.bounds.center.x,
                capsuleCollider.bounds.min.y + 0.35f,
                capsuleCollider.bounds.center.z
            ),
            0.4f,
            groundMask
        );
    }

    private void Update()
    {
        if (IsGrounded())
        {
            if (!grounded)
            {
                //playerDirection.y = 0f;
                grounded = true;
                Debug.Log("<b>[GROUNDED]: </b><color=green>YES</color>");
            }
            GroundMove();
        }
        else
        {
            grounded = false;
        }
        playerDirection.y -= Time.deltaTime * gravityStrength;
        rigidbody3D.velocity = playerDirection;

    }

    void GroundMove()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        float crouchModifier = characterCrouch.IsCrouching() ? 0.5f : 1f;
        float speed = forwardSpeed * crouchModifier * z;
        if (KeyManager.main.GetKey(Action.Sprint))
        {
            speed = sprintSpeed * crouchModifier * z;
        }
        if (z < 0)
        {
            speed = backWardSpeed * crouchModifier * z;
        }

        playerDirection = new Vector3(x * strafeSpeed, 0f, speed);
        
        if (KeyManager.main.GetKeyDown(Action.Jump) && !characterCrouch.IsCrouching())
        {
            playerDirection.y = jumpSpeed;
        }
        playerDirection = transform.TransformDirection(playerDirection);
        /*if (x > 0.05f)
        {
            //rigidbody3D.AddForce(transform.right.normalized * strafeSpeed * x, moveForceMode);
            //rigidbody3D.velocity = transform.right.normalized * strafeSpeed;
            //velocity.x = (transform.right * strafeSpeed * x * Time.deltaTime).x;
            velocity.x = strafeSpeed * transform.right.x;
        }
        else if (x < -0.05f)
        {
            //rigidbody3D.AddForce(transform.right.normalized * strafeSpeed * x, moveForceMode);
            //rigidbody3D.velocity = -transform.right.normalized * strafeSpeed;
            //velocity.x = (transform.right * strafeSpeed * x * Time.deltaTime).x;
            velocity.x = strafeSpeed * transform.right.x;
        }

        if (z > 0.05f)
        {
            float speed = forwardSpeed;
            if (KeyManager.main.GetKey(Action.Sprint))
            {
                speed = sprintSpeed;
            }
            //rigidbody3D.velocity = transform.forward.normalized * speed;
            //rigidbody3D.AddForce(transform.forward.normalized * speed * z, moveForceMode);
            //velocity.z = (transform.forward * speed * z * Time.deltaTime).z;
            velocity.z = speed * transform.forward.z;
        }
        else if (z < -0.05f)
        {
            //rigidbody3D.velocity = -transform.forward.normalized * backWardSpeed;
            //rigidbody3D.AddForce(transform.forward.normalized * backWardSpeed * z, moveForceMode);
            //velocity.z = (transform.forward * backWardSpeed * z * Time.deltaTime).z;
            velocity.z = backWardSpeed * transform.forward.z;
        }
        */
        //Debug.Log(velocity);
        /*
        rigidbody3D.velocity = velocity;*/
        /*if (Mathf.Abs(z) > startDragging || Mathf.Abs(x) > startDragging)
        {
            drag.DisableDrag();
        }
        else
        {
            //   Debug.Log("Dragging!");
            drag.EnableDrag();
        }*/
    }
}
