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

            anim.SetFloat("MoveX", moveX);
            anim.SetFloat("MoveZ", moveZ);
            anim.SetBool("isJumping", isJumping);
            anim.SetBool("isGrounded", isGrounded);
        }
    }
}
