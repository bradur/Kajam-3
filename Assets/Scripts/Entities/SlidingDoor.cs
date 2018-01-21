// Date   : 21.01.2018 19:43
// Project: Kajam #3
// Author : bradur

using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour
{

    private Transform playerTransform;

    [SerializeField]
    [Range(0.2f, 10f)]
    private float openingDistance = 1f;

    [SerializeField]
    [Range(2f, 10f)]
    private float closingDistance = 5f;

    private bool sliding = false;

    private Animator animator;

    void Start()
    {
        playerTransform = GameManager.main.GetPlayerTransform();
        animator = GetComponent<Animator>();
    }

    public void SlideIn()
    {
        sliding = true;
        animator.SetTrigger("SlideIn");
    }

    public void SlideOut()
    {
        sliding = false;
        animator.SetTrigger("SlideOut");
    }

    void Update()
    {
        if (!sliding)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) <= openingDistance)
            {
                SlideIn();
            }
        }
        else if (Vector3.Distance(transform.position, playerTransform.position) >= closingDistance)
        {
            SlideOut();
        }
    }
}
