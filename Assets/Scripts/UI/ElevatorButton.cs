// Date   : 26.01.2018 10:46
// Project: Kajam #3
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ElevatorButton : MonoBehaviour
{



    [SerializeField]
    private Text txtComponent;
    [SerializeField]
    private Color hoverColor;

    [SerializeField]
    private Color activeColor;
    [SerializeField]
    private Image knob;

    [SerializeField]
    private Transform callPosition;

    [SerializeField]
    private Elevator elevator;

    private Color originalColor;

    private void Start()
    {
        originalColor = knob.color;
    }

    private bool CallElevator()
    {
        return elevator.Call(callPosition.position, this);
    }

    public void ClickButton ()
    {
        if (CallElevator())
        {
            _ActivateButton();
        }
        
    }

    public void Enter()
    {
        knob.color = hoverColor;
        Debug.Log("Enter!");
    }

    public void Exit()
    {
        knob.color = originalColor;
        Debug.Log("Exit!");
    }

    public void ElevatorFinished()
    {
        knob.color = originalColor;
    }

    private void _ActivateButton()
    {
        knob.color = activeColor;
        Debug.Log("Activate!");
    }

}
