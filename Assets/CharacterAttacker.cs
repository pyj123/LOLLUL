using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterAnimation))]
[RequireComponent(typeof(CharacterMove))]
public class CharacterAttacker : MonoBehaviour
{   
    private CharacterMove characterMove;
    private CharacterAnimation characterAnimation;
    

    private void Awake()
    {
        characterAnimation = GetComponent<CharacterAnimation>();
        characterMove = GetComponent<CharacterMove>();
    }

    public void AttackOn()
    {
        characterAnimation.SetAnimation(CharacterAnimState.AttackOn);
        characterMove.StopCharacter();
    }

    public void AttackOff()
    {
        characterAnimation.SetAnimation(CharacterAnimState.AttackOff);
    }

    //애니메이션 프레임에 넣어줘야함
    private void FireBullet()
    {

    }

}
