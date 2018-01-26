// Date   : 26.01.2018 09:59
// Project: Kajam #3
// Author : bradur

using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    private bool moving = false;
    private float speed;
    private float timer = 0f;

    private Vector3 targetPosition;
    private Vector3 startPosition;

    private float lerpStartTime;

    private float duration = 1f;

    private ElevatorButton currentButton;

    void Start () {
    }

    void Update () {
        if (moving)
        {
            float percentageComplete = (Time.time - lerpStartTime) / duration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, percentageComplete);
            if (percentageComplete >= 1f)
            {
                if (currentButton != null)
                {
                    currentButton.ElevatorFinished();
                }
                moving = false;
            }
        }
    }

    public bool Call(Vector3 position, ElevatorButton elevatorButton)
    {
        if (!moving && Vector3.Distance(transform.position, position) > 0.4f)
        {
            lerpStartTime = Time.time;
            startPosition = transform.position;
            targetPosition = startPosition;
            targetPosition.y = position.y;
            moving = true;
            currentButton = elevatorButton;
            return true;
        }
        return false;
    }
}
