using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalk");
    private readonly float magnituteThreshold = 0.5f;
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        PlayerManager.Instance.Player.controller.moveEvent += Move;
    }

    private void Move(Vector2 value)
    {
        animator.SetBool(IsWalking, value.magnitude > magnituteThreshold);
    }
}
