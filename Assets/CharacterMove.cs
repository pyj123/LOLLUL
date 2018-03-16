using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterAnimation))]
[RequireComponent(typeof(CharacterAttacker))]
public class CharacterMove : MonoBehaviour
{
    private CharacterAnimation characterAnimation;
    private CharacterAttacker characterAttacker;
    private Rigidbody rb;

    //속성
    [SerializeField]
    private float moveSpeed = 1f;
    private float angle = 0f;
    private float rotateSpeed = 25f;

    //이동
    private Vector3 moveTarget = Vector3.zero;
    private float stopDistance = 0.5f;
    private NavMeshAgent navAgent;
    private bool nowAutoMove = false;

    //레이어마스크
    private int bottomLayerMask;
    private int obstacleLayerMask;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
        characterAnimation = GetComponent<CharacterAnimation>();
        characterAttacker = GetComponent<CharacterAttacker>();

        bottomLayerMask = 1 << LayerMask.NameToLayer("Bottom");
        obstacleLayerMask = 1 << LayerMask.NameToLayer("Obstacle");


    }

    private bool HasObstacle(Vector3 targetPos)
    {
        Ray ray = new Ray(this.transform.position, targetPos - this.transform.position);
        if (Physics.Raycast(ray, 100, obstacleLayerMask) == true)
        {
            return true;
        }

        return false;
    }

    void Update()
    {
      //  ButtonInput();
        Rotation();
        AutoStop();
        ChangeAnimation();

    }

    void ChangeAnimation()
    {
        if (nowAutoMove == false)
            characterAnimation.SetSpeed(rb.velocity.magnitude);
        else
            characterAnimation.SetSpeed(navAgent.speed);
    }

    public void MoveToTarget()
    {
        characterAttacker.AttackOff();

#if UNITY_EDITOR      
            Move();        
#else       
            Move();        
#endif

    }

    void AutoMoveStart(Vector3 moveTarget)
    {
        nowAutoMove = true;
        rb.velocity = Vector3.zero;
        navAgent.destination = moveTarget;
        navAgent.isStopped = false;
        navAgent.speed = moveSpeed;
        this.moveTarget = moveTarget;
    }

    void AutoMoveStop()
    {
        nowAutoMove = false;
        navAgent.speed = 0f;
        navAgent.isStopped = true;
    }

    void Move()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo, 100f, bottomLayerMask) == true)
        {
            //장애물 검사
            if (HasObstacle(hitInfo.point) == true)
            {
                AutoMoveStart(hitInfo.point);
                return;
            }
            //자동이동 중이었으면 꺼줌
            if (nowAutoMove == true)
                AutoMoveStop();

            //바라보는 각도 계산
            CalRotateAngle(hitInfo.point);

            //실제 이동
            this.moveTarget = hitInfo.point;
            rb.velocity = moveSpeed * (hitInfo.point -this.transform.position).normalized;

        }
    }

    void CalRotateAngle(Vector3 moveTarget)
    {
        Vector3 diff = moveTarget - this.transform.position;
        angle = Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg;
    }
    void AutoStop()
    {
        if (Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), new Vector2(moveTarget.x, moveTarget.z)) <= stopDistance)
        {
            StopCharacter();
        }
    }


    void Rotation()
    {
        if (nowAutoMove == true)
        {
            moveTarget = navAgent.destination;
            CalRotateAngle(navAgent.steeringTarget);
        }

        transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0f, -angle + 90f, 0f), Time.deltaTime * rotateSpeed);
    }

    public void StopCharacter()
    {
        if (nowAutoMove == true)
            AutoMoveStop();
        else
            rb.velocity = Vector3.zero;
    }
}
