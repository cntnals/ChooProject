using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;
    public int HP = 10;

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f));
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.I))
        {
            this.transform.Translate(new Vector3(0.0f, 0.0f, speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.K))
        {
            this.transform.Translate(new Vector3(0.0f, 0.0f, -speed * Time.deltaTime));
        }
    }
    void Reset()
    {
        // Try to get groundCheck.
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        // Get rigidbody.
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        // Jump when the Jump button is pressed and we are on the ground.
        if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded))
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
        }
    }
}
