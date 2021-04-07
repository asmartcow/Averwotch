using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Averwotch.Player.Globals
{
    public class PlayerSettings : MonoBehaviour
    {
        //Local Public Variables\\
        [Header("Player Controls Settings")]
        public KeyCode forwardMove;
        public KeyCode backwardMove;
        public KeyCode leftMove;
        public KeyCode rightMove;

        [Space]
        [Header("Player Movement Settings")]
        public float playerSpeed;
        public float gravityConstant;
        public float isGroundedRaycastLength;
        public GameObject raycastStart;

        [Space]
        [Header("Player Camera Settings")]
        public float cameraSpeed;
        public GameObject playerForwardLook;

        [Space]
        [Header("Player Jump Settings")]
        public bool canDoubleJump;
        public int maxJumps;

        [Space]
        [Header("Camera Settings")]
        public float jumpHeight;
        public float smoothTime;
        public GameObject mainCamera;
        public GameObject followObject;

        [Space]
        [Header("Layer Masks")]
        public LayerMask groundLayer;

        [Space]
        [Header("Animations")]
        [ShowOnly] public float moveX;
        [ShowOnly] public float moveZ;
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

        public static KeyCode _forwardMove { get; set; }
        public static KeyCode _backwardMove { get; set; }
        public static KeyCode _leftMove { get; set; }
        public static KeyCode _rightMove { get; set; }

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
            _forwardMove = forwardMove;
            _backwardMove = backwardMove;
            _leftMove = leftMove;
            _rightMove = rightMove;
        }
    }
}
