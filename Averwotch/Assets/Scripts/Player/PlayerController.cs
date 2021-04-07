using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Averwotch.Player.Globals;

namespace Averwotch.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        //Displayed Variables\\
        [Header("Player Controls")]
        [ShowOnly] public KeyCode pc_forward;
        [ShowOnly] public KeyCode pc_backward;
        [ShowOnly] public KeyCode pc_left;
        [ShowOnly] public KeyCode pc_right;
        
        [Space]
        [Header("Player Movement")]
        [ShowOnly] public Vector3 p_moveVelocity;
        [ShowOnly] public bool p_isGrounded;
        public LayerMask e_ground;
        [ShowOnly] public float p_speed;
        [ShowOnly] public float p_gravity;

        [Space]
        [Header("Jumping")]
        [ShowOnly] public bool p_canDoubleJump;
        [ShowOnly] public int p_jumpCount;
        [ShowOnly] public int p_maxJumps;
        //=-=-=-=-=-=-=\\

        //Hidden Variables\\
        private float p_jumpHeight;
        private float p_groundedRayLength;
        private float c_speed;

        private Vector3 p_velocity;

        private CharacterController p_controller;

        private GameObject p_rayStart;
        private GameObject c_main;
        private GameObject c_lookAt;
        //=-=-=-=-=-=-=\\

        void Start()
        {
            p_controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            p_speed = PlayerSettings._playerSpeed;
            p_jumpHeight = PlayerSettings._jumpHeight;
            p_gravity = PlayerSettings._gravity;
            p_rayStart = PlayerSettings._isGroundedStart;
            e_ground = PlayerSettings._groundMask;
            p_canDoubleJump = PlayerSettings._canDoubleJump;
            p_maxJumps = PlayerSettings._maxJumps - 1;
            p_groundedRayLength = PlayerSettings._isgroundedRayLength;
            c_main = PlayerSettings._playerCamera;
            c_speed = PlayerSettings._cameraSpeed;
            c_lookAt = PlayerSettings._playerForward;
            pc_forward = PlayerSettings._forwardMove;
            pc_backward = PlayerSettings._backwardMove;
            pc_left = PlayerSettings._leftMove;
            pc_right = PlayerSettings._rightMove;

            CheckGrounded();
            MovePlayer();
            Jumping();
        }

        private void CheckGrounded()
        {
            if(Physics.Raycast(p_rayStart.transform.position, -transform.up, p_groundedRayLength, e_ground))
            {
                Debug.DrawRay(p_rayStart.transform.position, -transform.up, Color.yellow, .2f);
                p_isGrounded = true;
                p_jumpCount = 0;
            }
            else
            {
                p_isGrounded = false;
            }
        }

        private void Gravity()
        {
            if (p_isGrounded && p_velocity.y < 0)
            {
                p_velocity.y = 0f;
            }
            else
            {
                p_velocity.y += p_gravity * Time.deltaTime;
            }
        }

        private void MovePlayer()
        {
            Gravity();

            Vector3 targetPos = new Vector3(c_lookAt.transform.position.x, this.transform.position.y, c_lookAt.transform.position.z);
            this.transform.LookAt(targetPos);

            Vector3 movement = Vector3.zero;

            movement += transform.forward * Input.GetAxis("Vertical");
            movement += transform.right * Input.GetAxis("Horizontal");

            p_controller.Move(movement.normalized * Time.deltaTime * p_speed);

            if (movement != Vector3.zero)
            {
                transform.position = movement;
            }

            p_controller.Move(p_velocity * Time.deltaTime);
        }

        private void Jumping()
        {
            if(Input.GetButtonDown("Jump") && p_isGrounded)
            {
                p_velocity.y += Mathf.Sqrt(p_jumpHeight * -3.0f * p_gravity);
                p_jumpCount++;
            }
            if (Input.GetButtonDown("Jump") && !p_isGrounded && p_canDoubleJump && p_jumpCount < p_maxJumps)
            {
                p_jumpCount++;
                p_velocity.y += Mathf.Sqrt(p_jumpHeight * -3.0f * p_gravity);
            }
        }
    }
}
