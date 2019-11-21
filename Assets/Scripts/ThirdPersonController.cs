using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    public float speed = 0.1f;
    public float runSpeed = 9.0f;
    public float turnSpeed = 90.0f;

    private Rigidbody rb;
    private Vector3 movement;
    private Quaternion rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement.Set(horizontal, 0.0f, vertical);
        movement.Normalize();

        Vector3 newForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(newForward);

        rb.MovePosition(rb.position + movement * speed);
        rb.MoveRotation(rotation);

    }
}
