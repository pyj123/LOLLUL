using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterAnimState
{
    Idle,Run,Attack
}

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimation(CharacterAnimState animState)
    {
        switch (animState)
        {
            case CharacterAnimState.Idle:
                {

                } break;
            case CharacterAnimState.Run:
                {

                }
                break;
            case CharacterAnimState.Attack:
                {

                }
                break;
        }
    }

    public void SetSpeed(float speed)
    {
        animator.SetFloat("Speed", speed);
    }


 
}
