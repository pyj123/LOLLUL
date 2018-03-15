using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float zDistance;

    [SerializeField]
    private float yDistance;

    [SerializeField]
    private float xAngle;

#if UNITY_EDITOR
    private void OnValidate()
    {
        FollowTarget();
    }
#endif

    // Update is called once per frame
    void Update()
    {
        FollowTarget();

    }


    void FollowTarget()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y + yDistance, target.position.z + zDistance);
        this.transform.position = targetPos;
        this.transform.rotation = Quaternion.Euler(xAngle, 0f, 0f);
    }

  
}
