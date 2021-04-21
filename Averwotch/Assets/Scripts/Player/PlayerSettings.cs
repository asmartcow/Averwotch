using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Averwotch.Player.Globals
{
    public class PlayerSettings : MonoBehaviour
    {
        //----------Local Public Variables----------\\
        //-----Game Settings-----\\
        //Inventory\\
        [Title("Inventory", "", TitleAlignments.Centered)]
        [FoldoutGroup("Game Settings", expanded: true)] public int invSize;

        //Moving\\
        [Title("Moving", "", TitleAlignments.Centered)]
        [FoldoutGroup("Game Settings", expanded: true)] public float playerSpeed;
        [FoldoutGroup("Game Settings", expanded: true)] public float gravityConstant;

        //Jumping\\
        [Title("Jumping", "", TitleAlignments.Centered)]
        [FoldoutGroup("Game Settings", expanded: true)] public bool canDoubleJump;
        [FoldoutGroup("Game Settings", expanded: true)] public int maxJumps;
        [FoldoutGroup("Game Settings", expanded: true)] public float jumpHeight;

        //-----User Changeable Settings-----\\
        //Camera\\
        [Title("Variables", "", TitleAlignments.Centered)]
        [FoldoutGroup("User Changeable Settings", expanded: true)] public float cameraSpeed;

        //-----Back End-----\\
        //Camera\\
        [Title("Camera", "", TitleAlignments.Centered)]
        [FoldoutGroup("Back End Settings", expanded: true)] public bool mouseLock;
        [FoldoutGroup("Back End Settings", expanded: true)] public float camClampMin;
        [FoldoutGroup("Back End Settings", expanded: true)] public float camClampMax;

        //Object References\\
        [Title("Object References", "", TitleAlignments.Centered)]
        [FoldoutGroup("Back End Settings", expanded: true)] public GameObject raycastStart;
        [FoldoutGroup("Back End Settings", expanded: true)] public GameObject playerForwardLook;
        [FoldoutGroup("Back End Settings", expanded: true)] public GameObject mainCamera;
        [FoldoutGroup("Back End Settings", expanded: true)] public GameObject followObject;

        //Raycasts\\
        [Title("Raycast", "", TitleAlignments.Centered)]
        [FoldoutGroup("Back End Settings", expanded: true)] public float isGroundedRaycastLength;

        //Layers\\
        [Title("Layer Mask", "", TitleAlignments.Centered)]
        [FoldoutGroup("Back End Settings", expanded: true)] public LayerMask groundLayer;

        //-----Show Only-----\\
        //Animations\\
        [Title("Animations", "", TitleAlignments.Centered)]
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public bool isJumping;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public bool isGrounded;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public float moveX;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public float moveZ;

        //Collisions\\
        [Title("Collisions", "", TitleAlignments.Centered)]
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public bool destroyed;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public bool drop;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public bool weaponPickup;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public string collidedWith;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public string collidedTag;

        //Object References\\
        [Title("Object References", "", TitleAlignments.Centered)]
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public GameObject collided;

        //Other\\
        [Title("Active Weapons", "", TitleAlignments.Centered)]
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public int activeWeapon;
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
        public static float _camClampMin { get; set; }
        public static float _camClampMax { get; set; }

        public static string _collidedWith { get; set; }
        public static string _collidedTag { get; set; }

        public static int _maxJumps { get; set; }
        public static int _invSize { get; set; }
        public static int _activeWeapon { get; set; }

        public static bool _canDoubleJump { get; set; }
        public static bool _mouseLock { get; set; }
        public static bool _destroying { get; set; }
        public static bool _isJumping { get; set; }
        public static bool _isGrounded { get; set; }
        public static bool _weaponPickup { get; set; }
        public static bool _drop { get; set; }

        public static LayerMask _groundMask { get; set; }

        public static GameObject _playerCamera { get; set; }
        public static GameObject _playerForward { get; set; }
        public static GameObject _isGroundedStart { get; set; }
        public static GameObject _followObject { get; set; }
        public static GameObject _collided { get; set; }
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
            _camClampMin = camClampMin;
            _camClampMax = camClampMax;
            _mouseLock = mouseLock;
            collidedTag = _collidedTag;
            collidedWith = _collidedWith;
            collided = _collided;
            destroyed = _destroying;
            drop = _drop;
            weaponPickup = _weaponPickup;
            isJumping = _isJumping;
            isGrounded = _isGrounded;
            _invSize = invSize;
            activeWeapon = _activeWeapon;
        }
    }
}
