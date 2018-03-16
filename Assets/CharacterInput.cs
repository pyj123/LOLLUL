using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterMove))]
public class CharacterInput : MonoBehaviour
{
    private CharacterMove characterMove;
    private CharacterAttacker characterAttacker;

    private void Awake()
    {
        characterMove = GetComponent<CharacterMove>();
        characterAttacker = GetComponent<CharacterAttacker>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            characterMove.MoveToTarget();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            characterAttacker.AttackOn();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            characterAttacker.AttackOff();
        }
#else
            if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            characterMove.MoveToTarget();
        }
#endif

    }

}
