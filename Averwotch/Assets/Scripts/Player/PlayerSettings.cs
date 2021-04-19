using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Averwotch.Player.Globals
{
    public class PlayerSettings : MonoBehaviour
    {
        //Local Public Variables\\
        //Movement\\
        [Title("Moving", "", TitleAlignments.Centered)]
        [FoldoutGroup("Player Movement Settings", expanded: false)] public float playerSpeed;
        [FoldoutGroup("Player Movement Settings", expanded: false)] public float gravityConstant;
        [FoldoutGroup("Player Movement Settings", expanded: false)] public float isGroundedRaycastLength;

        //Jumping\\
        [Title("Jumping", "", TitleAlignments.Centered)]
        [FoldoutGroup("Player Movement Settings", expanded: false)] public bool canDoubleJump;
        [FoldoutGroup("Player Movement Settings", expanded: false)] public int maxJumps;
        [FoldoutGroup("Player Movement Settings", expanded: false)] public float jumpHeight;
        [FoldoutGroup("Player Movement Settings", expanded: false)] public float smoothTime;

        //Movement object references\\
        [Title("Object References", "", TitleAlignments.Centered)]
        [FoldoutGroup("Player Movement Settings", expanded: false)] public GameObject raycastStart;

        //Camera\\
        [Title("Variables", "", TitleAlignments.Centered)]
        [FoldoutGroup("Player Camera settings", expanded: false)] public float cameraSpeed;

        //Camera Object References\\
        [Title("Object References", "", TitleAlignments.Centered)]
        [FoldoutGroup("Player Camera settings", expanded: false)] public GameObject playerForwardLook;
        [FoldoutGroup("Player Camera settings", expanded: false)] public GameObject mainCamera;
        [FoldoutGroup("Player Camera settings", expanded: false)] public GameObject followObject;

        //Layer Masks\\
        [Title("Layer Mask", "", TitleAlignments.Centered)]
        [FoldoutGroup("Layer Mask settings", expanded: false)] public LayerMask groundLayer;

        //ShowOnly\\
        [Title("Show Only", "", TitleAlignments.Centered)]
        [FoldoutGroup("Animations", expanded: false)] [ShowOnly] public float moveX;
        [FoldoutGroup("Animations", expanded: false)] [ShowOnly] public float moveZ;
        //-----------------\\

        //Set Global Usables\\
        public static float _playerSpeed { get; set; }
        public static float _jumpHeight{ get; set; }
        public static float _cameraSpeed { get; set; }
        public static float _gravity { get; set; }
        public static float _smoothTime { get; set; }
        public static float _isgroundedRayLength { get; set; }
        public static float _moveX { get; set; }
        public static float _moveZ { get; set; }

        public static int _maxJumps { get; set; }

        public static bool _canDoubleJump { get; set; }

        public static LayerMask _groundMask { get; set; }

        public static GameObject _playerCamera { get; set; }
        public static GameObject _playerForward { get; set; }
        public static GameObject _isGroundedStart { get; set; }
        public static GameObject _followObject { get; set; }
        //-----------------\\

        public void Update()
        {
            _playerSpeed = playerSpeed;
            _jumpHeight = jumpHeight;
            _cameraSpeed = cameraSpeed;
            _playerCamera = mainCamera;
            _playerForward = playerForwardLook;
            _groundMask = groundLayer;
            _isGroundedStart = raycastStart;
            _gravity = gravityConstant;
            _followObject = followObject;
            _smoothTime = smoothTime;
            _canDoubleJump = canDoubleJump;
            _maxJumps = maxJumps;
            _isgroundedRayLength = isGroundedRaycastLength;
            moveX = _moveX;
            moveZ = _moveZ;
        }
    }
}
