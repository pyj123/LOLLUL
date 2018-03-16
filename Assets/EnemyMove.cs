using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    Rigidbody rb;

    private float moveSpeed = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

 
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 moveDir = target.position - this.transform.position;
        rb.velocity = moveDir.normalized * moveSpeed;
	}
}
