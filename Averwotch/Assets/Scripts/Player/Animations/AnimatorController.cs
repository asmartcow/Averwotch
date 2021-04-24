using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Averwotch.Player.Globals;

namespace Averwotch.Player.Animation
{
    public class AnimatorController : MonoBehaviour
    {
        public Animator anim;

        [ShowOnly] public float moveX;
        [ShowOnly] public float moveZ;
        [ShowOnly] public bool isJumping;
        [ShowOnly] public bool isGrounded;
        [ShowOnly] public float smoothTime = 0.3f;
        [ShowOnly] public float yVelocity = 0.0f;
        [ShowOnly] public bool weaponActive;

        public void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void Update()
        {
            moveX = PlayerSettings._moveX;
            moveZ = PlayerSettings._moveZ;
            isJumping = PlayerSettings._isJumping;
            isGrounded = PlayerSettings._isGrounded;
            weaponActive = PlayerSettings._isWeaponActive;

            anim.SetFloat("MoveX", moveX);
            anim.SetFloat("MoveZ", moveZ);
            anim.SetBool("isJumping", isJumping);
            anim.SetBool("isGrounded", isGrounded);
            anim.SetBool("WeaponActive", weaponActive);
        }
    }
}
