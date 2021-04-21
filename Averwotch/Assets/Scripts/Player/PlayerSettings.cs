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
        [Title("Inventory", "", TitleAlignments.Centered)]
        [FoldoutGroup("Game Settings", expanded: true)] public int invSize;

        [Title("Moving", "", TitleAlignments.Centered)]
        [FoldoutGroup("Player Movement Settings", expanded: true)] public float playerSpeed;
        [FoldoutGroup("Player Movement Settings", expanded: true)] public float gravityConstant;
        [FoldoutGroup("Player Movement Settings", expanded: true)] public float isGroundedRaycastLength;

        //Jumping\\
        [Title("Jumping", "", TitleAlignments.Centered)]
        [FoldoutGroup("Player Movement Settings", expanded: true)] public bool canDoubleJump;
        [FoldoutGroup("Player Movement Settings", expanded: true)] public int maxJumps;
        [FoldoutGroup("Player Movement Settings", expanded: true)] public float jumpHeight;
        [FoldoutGroup("Player Movement Settings", expanded: true)] public float smoothTime;

        //Movement object references\\
        [Title("Object References", "", TitleAlignments.Centered)]
        [FoldoutGroup("Player Movement Settings", expanded: true)] public GameObject raycastStart;

        //Camera\\
        [Title("Variables", "", TitleAlignments.Centered)]
        [FoldoutGroup("Player Camera settings", expanded: true)] public bool mouseLock;
        [FoldoutGroup("Player Camera settings", expanded: true)] public float cameraSpeed;
        [FoldoutGroup("Player Camera settings", expanded: true)] public float camClampMin;
        [FoldoutGroup("Player Camera settings", expanded: true)] public float camClampMax;

        //Camera Object References\\
        [Title("Object References", "", TitleAlignments.Centered)]
        [FoldoutGroup("Player Camera settings", expanded: true)] public GameObject playerForwardLook;
        [FoldoutGroup("Player Camera settings", expanded: true)] public GameObject mainCamera;
        [FoldoutGroup("Player Camera settings", expanded: true)] public GameObject followObject;

        //Layer Masks\\
        [Title("Layer Mask", "", TitleAlignments.Centered)]
        [FoldoutGroup("Layer Mask settings", expanded: true)] public LayerMask groundLayer;

        //ShowOnly\\
        [Title("Animations", "", TitleAlignments.Centered)]
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public bool isJumping;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public bool isGrounded;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public float moveX;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public float moveZ;

        [Title("Collisions", "", TitleAlignments.Centered)]
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public bool destroyed;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public bool drop;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public bool weaponPickup;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public string collidedWith;
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public string collidedTag;

        [Title("GameObjects", "", TitleAlignments.Centered)]
        [FoldoutGroup("ShowOnly", expanded: true)] [ShowOnly] public GameObject collided;

        [Title("Active Weapons", "", TitleAlignments.Centered)]
        [FoldoutGroup("Usables", expanded: true)] [ShowOnly] public int activeWeapon;
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
