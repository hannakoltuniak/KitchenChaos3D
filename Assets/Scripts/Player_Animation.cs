using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    [SerializeField] private Player_Movement player;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.Is_Walking());
    }
}
