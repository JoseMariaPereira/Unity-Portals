using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FlyingCrow.PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;

        [Range(1,5)][SerializeField] private float speed;

        [SerializeField] private float gravity = -9.81f;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundDist = 0.4f;
        [SerializeField] private LayerMask groundLayer;

        private Vector3 velocity;

        // Update is called once per frame
        void Update()
        {
            CharacterMovement();
        }

        private void CharacterMovement()
        {
            if (Physics.CheckSphere(groundCheck.position, groundDist, groundLayer))
            {
                velocity.y = -2;
            }

            float xAxis = Input.GetAxis("Horizontal");
            float zAxis = Input.GetAxis("Vertical");

            Vector3 move = transform.right * xAxis + transform.forward * zAxis;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            Debug.Log(velocity);
        }
    }
}
