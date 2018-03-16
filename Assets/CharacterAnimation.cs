using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterAnimState
{
    AttackOn, AttackOff
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
            case CharacterAnimState.AttackOn:
                {
                    if (animator.GetBool("AttackOn") == false)
                        animator.SetBool("AttackOn", true);
                }
                break;
            case CharacterAnimState.AttackOff:
                {
                    if (animator.GetBool("AttackOn") == true)
                        animator.SetBool("AttackOn", false);
                }
                break;
        }
    }

    public void SetSpeed(float speed)
    {
        animator.SetFloat("Speed", speed);
    }



}
