using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Averwotch.Player.Globals;
using Averwotch.Player.Inventory;
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
        [FoldoutGroup("Jumping ShowOnly", expanded: true)] [ShowOnly] public bool p_isJumping;
        [FoldoutGroup("Jumping ShowOnly", expanded: true)] [ShowOnly] public bool p_canDoubleJump;
        [FoldoutGroup("Jumping ShowOnly", expanded: true)] [ShowOnly] public int p_jumpCount;
        [FoldoutGroup("Jumping ShowOnly", expanded: true)] [ShowOnly] public int p_maxJumps;

        [Title("Pickups", "", TitleAlignments.Centered)]
        [InfoBox("These settings are configured on the PlayerSettings Manager")]
        [FoldoutGroup("Collider", expanded: true)] [ShowOnly] public bool destroyed;
        [FoldoutGroup("Collider", expanded: true)] [ShowOnly] public bool drop;
        [FoldoutGroup("Collider", expanded: true)] [ShowOnly] public string t_collidedWith;
        [FoldoutGroup("Collider", expanded: true)] [ShowOnly] public string t_collidedTag;
        [FoldoutGroup("Collider", expanded: true)] [ShowOnly] public GameObject t_collided;

        [Title("Active Weapons", "", TitleAlignments.Centered)]
        [InfoBox("These settings are configured on the PlayerSettings Manager")]
        [FoldoutGroup("Usables", expanded: true)] [ShowOnly] public int activeWeapon;
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
            ca.use.AddDefaultBinding(Key.F);
            ca.drop.AddDefaultBinding(Key.Q);
            ca.wep1.AddDefaultBinding(Key.Key1);
            ca.wep2.AddDefaultBinding(Key.Key2);
            ca.wep3.AddDefaultBinding(Key.Key3);
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
            t_collidedTag = PlayerSettings._collidedTag;
            t_collidedWith = PlayerSettings._collidedWith;
            t_collided = PlayerSettings._collided;
            PlayerSettings._destroying = destroyed;
            PlayerSettings._drop = drop;
            PlayerSettings._isJumping = p_isJumping;
            PlayerSettings._isGrounded = p_isGrounded;
            PlayerSettings._activeWeapon = activeWeapon;

            CheckGrounded();
            MovePlayer();
            Jumping();
            Pickup();
            ActiveWeapon();
            Drop();
        }

        private void CheckGrounded()
        {
            if(Physics.Raycast(p_rayStart.transform.position, -transform.up, p_groundedRayLength, e_ground))
            {
                Debug.DrawRay(p_rayStart.transform.position, -transform.up, Color.yellow, .2f);
                p_isGrounded = true;
                p_jumpCount = 0;
                p_isJumping = false;
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
                p_velocity.y = -1f;
            }
            else
            {
                p_velocity.y += p_gravity * Time.deltaTime;
            }
        }

        private void MovePlayer()
        {
            Gravity();

            Vector3 targetPos = new Vector3(c_lookAt.transform.position.x, this.transform.localPosition.y, c_lookAt.transform.position.z);
            this.transform.LookAt(targetPos);

            Vector3 movement = Vector3.zero;

            movement += transform.forward * -ca.moveFB;
            movement += transform.right * ca.moveLR;

            p_controller.Move(movement.normalized * Time.deltaTime * p_speed);

            p_controller.Move(p_velocity * Time.deltaTime);

            var velocity = transform.InverseTransformDirection(movement);

            PlayerSettings._moveX = velocity.normalized.x * p_speed;
            PlayerSettings._moveZ = velocity.normalized.z * p_speed;
        }

        private void Jumping()
        {
            if(ca.jump.WasPressed && p_isGrounded)
            {
                p_isJumping = true;
                p_velocity.y += Mathf.Sqrt(p_jumpHeight * -3.0f * p_gravity);
                p_jumpCount++;
            }
            if (ca.jump.WasPressed && !p_isGrounded && p_canDoubleJump && p_jumpCount < p_maxJumps)
            {
                p_isJumping = true;
                p_jumpCount++;
                p_velocity.y += Mathf.Sqrt(p_jumpHeight * -3.0f * p_gravity);
            }
        }

        private void Pickup()
        {
            if (ca.use.WasPressed && t_collidedTag == "Weapon")
            {
                destroyed = false;
                PlayerSettings._weaponPickup = true;
            }
        }

        private void Drop()
        {
            if (ca.drop.WasPressed)
            {
                PlayerSettings._drop = true;
            }
            else
            {
                PlayerSettings._drop = false;
            }
        }

        private void ActiveWeapon()
        {
            if (ca.wep1.WasPressed)
            {
                activeWeapon = 0;
            }
            if (ca.wep2.WasPressed)
            {
                activeWeapon = 1;
            }
            if (ca.wep3.WasPressed)
            {
                activeWeapon = 2;
            }
        }
    }
}
