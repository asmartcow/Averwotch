using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Averwotch.Player.Globals;
using Sirenix.OdinInspector;
using InControl;

namespace Averwotch.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        //Displayed Variables\\
        [Title("Movement", "", TitleAlignments.Centered)]
        [InfoBox("These settings are configured on the PlayerSettings Manager")]
        [FoldoutGroup("Movement ShowOnly", expanded: true)] [ShowOnly] public Vector3 p_moveVelocity;
        [FoldoutGroup("Movement ShowOnly", expanded: true)] [ShowOnly] public bool p_isGrounded;
        [FoldoutGroup("Movement ShowOnly", expanded: true)] [ShowOnly] public LayerMask e_ground;
        [FoldoutGroup("Movement ShowOnly", expanded: true)] [ShowOnly] public float p_speed;
        [FoldoutGroup("Movement ShowOnly", expanded: true)] [ShowOnly] public float p_gravity;

        [Title("Jumping", "", TitleAlignments.Centered)]
        [InfoBox("These settings are configured on the PlayerSettings Manager")]
        [FoldoutGroup("Jumping ShowOnly", expanded: true)] [ShowOnly] public bool p_canDoubleJump;
        [FoldoutGroup("Jumping ShowOnly", expanded: true)] [ShowOnly] public int p_jumpCount;
        [FoldoutGroup("Jumping ShowOnly", expanded: true)] [ShowOnly] public int p_maxJumps;
        //=-=-=-=-=-=-=\\

        //Hidden Variables\\
        private CharacterActions ca;

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

            ca = new CharacterActions();

            ca.left.AddDefaultBinding(Key.A);
            ca.right.AddDefaultBinding(Key.D);
            ca.forward.AddDefaultBinding(Key.W);
            ca.backward.AddDefaultBinding(Key.S);
            ca.jump.AddDefaultBinding(Key.Space);
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

            movement += transform.forward * -ca.moveFB;
            movement += transform.right * ca.moveLR;

            p_controller.Move(movement.normalized * Time.deltaTime * p_speed);

            /*if (movement != Vector3.zero)
            {
                transform.position = movement;
            }*/

            p_controller.Move(p_velocity * Time.deltaTime);
        }

        private void Jumping()
        {
            if(ca.jump.WasPressed && p_isGrounded)
            {
                p_velocity.y += Mathf.Sqrt(p_jumpHeight * -3.0f * p_gravity);
                p_jumpCount++;
            }
            if (ca.jump.WasPressed && !p_isGrounded && p_canDoubleJump && p_jumpCount < p_maxJumps)
            {
                p_jumpCount++;
                p_velocity.y += Mathf.Sqrt(p_jumpHeight * -3.0f * p_gravity);
            }
        }
    }
}
