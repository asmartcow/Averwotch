using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using Sirenix.OdinInspector;

namespace Controllers.RB.Player
{
    public class Player : MonoBehaviour
    {
        //Public Variables\\
        [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private Rigidbody rb;
        [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private bool isGrounded;
        [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private bool isDoubleJump;
        [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private bool canMove;

        [Title("Movement", "", TitleAlignments.Centered)]
        [FoldoutGroup("Variables")] public LayerMask playerLayer;
        [FoldoutGroup("Variables")] public float turnSpeed;
        [FoldoutGroup("Variables")] public float speed;
        [FoldoutGroup("Variables")] public float jumpSpeedMultiplier;
        [FoldoutGroup("Variables")] public float jumpHeight;
        [FoldoutGroup("Variables")] public bool canDoubleJump;
        [FoldoutGroup("Variables")] public bool canMoveWhileJumping;

        [Title("Raycasts", "", TitleAlignments.Centered)]
        [FoldoutGroup("Variables")] public GameObject raycastObject;
        //\\

        //Private Variables\\
        private CharacterActions ca;
        private Vector3 direction = Vector3.right;
        private Vector3 moveVelocity;
        //\\

        private void Awake()
        {
            //Debug.Log("Initializing...");

            //Initialize Rigidbody\\
            rb = GetComponent<Rigidbody>();
            //\\

            //Initialize Control Scheme\\
            ca = new CharacterActions();
            ca.left.AddDefaultBinding(Key.A);
            ca.right.AddDefaultBinding(Key.D);
            ca.forward.AddDefaultBinding(Key.W);
            ca.backward.AddDefaultBinding(Key.S);
            ca.jump.AddDefaultBinding(Key.Space);
            ca.use.AddDefaultBinding(Key.F);
            ca.drop.AddDefaultBinding(Key.Q);
            ca.wep1.AddDefaultBinding(Key.Key1);
            ca.wep2.AddDefaultBinding(Key.Key2);
            ca.wep3.AddDefaultBinding(Key.Key3);
            ca.quicksave.AddDefaultBinding(Key.Escape);
            ca.quickload.AddDefaultBinding(Key.PadEnter);
            //\\
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Update()
        {
            direction = Camera.main.transform.forward;
            IsGroundedCheck();
            Raycast();
            Jumping();
        }

        private void Movement()
        {
            var currentRotation = rb.rotation;
            var horizontalDirection = Vector3.ProjectOnPlane(direction, Vector3.up);
            var targetRotation = Quaternion.LookRotation(horizontalDirection);
            var newRotation = Quaternion.Slerp(currentRotation, targetRotation, turnSpeed * Time.deltaTime);

            var FBPos = transform.forward * -ca.moveFB;
            var LRPos = transform.right * ca.moveLR;

            var move = (FBPos + LRPos);

            if (isGrounded)
            {
                moveVelocity = move.normalized;
            }

            if (canMove)
            {
                rb.MoveRotation(newRotation);
                if (!isGrounded)
                {
                    rb.MovePosition(rb.position + move.normalized * jumpSpeedMultiplier * Time.deltaTime);
                    rb.MovePosition(rb.position + moveVelocity.normalized * speed * Time.deltaTime); 
                }
                else
                {
                    rb.MovePosition(rb.position + move.normalized * speed * Time.deltaTime);
                }
            }

            if (!isGrounded && !canMoveWhileJumping)
            {
                rb.MoveRotation(newRotation);
                rb.MovePosition(rb.position + moveVelocity.normalized * speed * Time.deltaTime);
            }
        }

        private void Jumping()
        {
            if (ca.jump.WasPressed && isGrounded)
            {
                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            }
            if (ca.jump.WasPressed && isDoubleJump && !isGrounded)
            {
                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                isDoubleJump = false;
            }
        }

        private void IsGroundedCheck()
        {
            if (Physics.Raycast(raycastObject.transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, .15f, ~playerLayer))
            {
                isGrounded = true;
                Debug.DrawRay(raycastObject.transform.position, transform.TransformDirection(Vector3.down) * 10f, Color.green);
                isDoubleJump = canDoubleJump;
                canMove = true;
            }
            else
            {
                isGrounded = false;
                Debug.DrawRay(raycastObject.transform.position, transform.TransformDirection(Vector3.down) * 10f, Color.red);

                if ( canMoveWhileJumping )
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }
        }

        private void Raycast()
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5f, Color.blue);
        }
    }
}
