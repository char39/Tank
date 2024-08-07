using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A : 왼쪽으로 회전, D : 오른쪽으로 회전, W : 전진, S : 후진

public class TankMove : MonoBehaviour
{
    private Rigidbody rb;
    private Transform tr;
    private float tankBodyAngle = 8f;
    private float tankMoveSpeed = 10f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb.velocity = transform.forward * tankMoveSpeed;
        if (Input.GetKey(KeyCode.S))
            rb.velocity = -transform.forward * tankMoveSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            Quaternion targetRotation = Quaternion.Euler(0, -tankBodyAngle, 0) * tr.rotation;
            tr.rotation = Quaternion.Lerp(tr.rotation, targetRotation, Time.deltaTime * tankBodyAngle);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion targetRotation = Quaternion.Euler(0, tankBodyAngle, 0) * tr.rotation;
            tr.rotation = Quaternion.Lerp(tr.rotation, targetRotation, Time.deltaTime * tankBodyAngle);
        }

    }
}
