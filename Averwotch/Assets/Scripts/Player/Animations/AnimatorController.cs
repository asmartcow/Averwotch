using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Averwotch.Player.Globals;

namespace Averwotch.Player.Animation
{
    public class AnimatorController : MonoBehaviour
    {
        public GameObject player;
        public Animator anim;
        public float dampTime;

        [ShowOnly] public float moveX;
        [ShowOnly] public float moveZ;

        public void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void Update()
        {
            moveX = PlayerSettings._moveX;
            moveZ = PlayerSettings._moveZ;

            anim.SetFloat("MoveX", moveX);
            anim.SetFloat("MoveZ", moveZ);
        }
    }
}
