// Date   : 15.01.2018 21:35
// Project: Kajam #3
// Author : bradur

using UnityEngine;
using System.Collections;

public class CharacterCrouch : MonoBehaviour
{
    [SerializeField]
    private Transform crouchPosition;

    [SerializeField]
    private Transform erectPosition;

    private bool crouching = false;
    private bool switching = false;

    private Vector3 targetPosition;
    private float smoothingTimer = 0f;
    [SerializeField]
    [Range(0.2f, 50f)]
    private float speed;

    void Update()
    {
        if (!crouching && KeyManager.main.GetKeyDown(Action.Crouch))
        {
            //transform.localPosition = crouchPosition.localPosition;
            crouching = true;
            smoothingTimer = 0f;
            switching = true;
            targetPosition = crouchPosition.localPosition;
        }
        if (crouching)
        {
            if (KeyManager.main.GetKeyUp(Action.Crouch) || !KeyManager.main.GetKey(Action.Crouch))
            {
                //transform.localPosition = erectPosition.localPosition;
                crouching = false;
                smoothingTimer = 0f;
                targetPosition = erectPosition.localPosition;
            }
        }
        if (switching && Vector3.Distance(transform.localPosition, targetPosition) > 0.05f)
        {
            smoothingTimer += Time.deltaTime * speed;
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, smoothingTimer);
        }
    }
}
