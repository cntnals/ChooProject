using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyController : MonoBehaviour
{
    private Animator animator;
    public float speed = 1;
    private bool isTurned = false;
    private Rigidbody rb;

    private float currentSpeed = 0f;
    public float acceleration = 2f;
    

    Rigidbody rigidbody;
    public float jumpStrength = 5;
    public event System.Action Jumped;
    //public Vector3 direction { get; private set; }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
 

    void Update()
    {

        float targetSpeed = 0f;

        // W를 누르면 앞으로 이동
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("walk", true);
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            targetSpeed = speed;
            isTurned = false;
        }
        else
        {
            currentSpeed = 0f;
            animator.SetBool("walk", false);
        }

        // S를 누르면 180도 회전
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Turn");
            isTurned = true;
            transform.Rotate(0, 180, 0);
        }

        // Shift + W로 달리기
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            targetSpeed = speed*3f;
            animator.SetBool("run", true);
            //transform.Translate(Vector3.forward * speed * 3f * Time.deltaTime);  // 속도를 2배로 설정
        }
        // Shift + S로 뒤로 달리기
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("run", true);
            //transform.Translate(Vector3.back * speed * 3f * Time.deltaTime);  // 속도를 1.5배로 설정
            targetSpeed = -speed * 3f;
        }
        else
        {
            animator.SetBool("run", false);
        }

        if(targetSpeed>currentSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime; //가속하는 로직
        }
        //currentSpeed = Mathf.Clamp(currentSpeed, -speed * 3f, speed * 3f);
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // Space를 누르면 점프하고 살짝 앞으로 이동
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);  // 위쪽과 앞쪽으로 힘을 가함
            isTurned = true;
            Jumped?.Invoke();
        }
    }
}
