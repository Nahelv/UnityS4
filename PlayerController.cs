using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float speed = 8f;
    [SerializeField] float rotationSpeed = 100f;
    Vector3 verticalVelocity;
    [SerializeField] float jumpHeight = 5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        controller.Move((-transform.forward * z * speed + verticalVelocity) * Time.deltaTime);
        transform.Rotate(Vector3.up * x * rotationSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (controller.isGrounded) {
            verticalVelocity = Vector3.zero;
            if (Input.GetButton("Jump")) {
                verticalVelocity += Vector3.up * jumpHeight;
            } else if (Input.GetKey(KeyCode.LeftShift)) {
                speed = 16f;
            }
        } else {
            verticalVelocity += Physics.gravity * Time.fixedDeltaTime;
        }
    }
}
