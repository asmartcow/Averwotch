using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using Sirenix.OdinInspector;

namespace Controllers.RB.Player
{
    public class Player : MonoBehaviour
    {
        //Public Variables\\
        [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private Rigidbody rb;
        [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private bool isGrounded;
        [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private bool isDoubleJump;

        [Title("Movement", "", TitleAlignments.Centered)]
        [FoldoutGroup("Variables")] public LayerMask playerLayer;
        [FoldoutGroup("Variables")] public float speed;
        [FoldoutGroup("Variables")] public float jumpHeight;
        [FoldoutGroup("Variables")] public bool canDoubleJump;

        [Title("GameObjects", "", TitleAlignments.Centered)]
        [FoldoutGroup("Variables")] public GameObject raycastObject;

        [Title("List", "", TitleAlignments.Centered)]
        [FoldoutGroup("Inventory")] public InventoryObject inventory;
        //\\

        //Private Variables\\
        private CharacterActions ca;
        private Vector3 direction = Vector3.right;
        //\\

        private void Awake()
        {
            //Debug.Log("Initializing...");

            //Initialize Rigidbody\\
            rb = GetComponent<Rigidbody>();
            //\\

            //Initialize Control Scheme\\
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
            ca.quicksave.AddDefaultBinding(Key.Escape);
            ca.quickload.AddDefaultBinding(Key.PadEnter);
            //\\
        }

        private void Start()
        {
            /*if(rb != null)
            {
                Debug.Log("Rigidbody Initialized...");
            }
            if(ca != null)
            {
                Debug.Log("Character controls Initialized...");
            }*/
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Update()
        {
            direction = Camera.main.transform.forward;
            IsGroundedCheck();
            Raycast();
            Jumping();
            if (ca.quicksave.WasPressed)
            {
                inventory.Save();
            }
            if (ca.quickload.WasPressed)
            {
                inventory.Load();
            }
        }

        private void Movement()
        {
            var currentRotation = rb.rotation;
            var horizontalDirection = Vector3.ProjectOnPlane(direction, Vector3.up);
            var targetRotation = Quaternion.LookRotation(horizontalDirection);
            var newRotation = Quaternion.Slerp(currentRotation, targetRotation, 10f * Time.deltaTime);

            var FBPos = transform.forward * -ca.moveFB;
            var LRPos = transform.right * ca.moveLR;

            var move = (FBPos + LRPos);

            rb.MoveRotation(newRotation);
            rb.MovePosition(rb.position + move.normalized * speed * Time.deltaTime);
        }

        private void Jumping()
        {
            if (ca.jump.WasPressed && isGrounded)
            {
                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            }
            if (ca.jump.WasPressed && isDoubleJump && !isGrounded)
            {
                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                isDoubleJump = false;
            }
        }

        private void IsGroundedCheck()
        {
            if (Physics.Raycast(raycastObject.transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, .15f, ~playerLayer))
            {
                isGrounded = true;
                Debug.DrawRay(raycastObject.transform.position, transform.TransformDirection(Vector3.down) * 10f, Color.green);
                isDoubleJump = canDoubleJump;
            }
            else
            {
                isGrounded = false;
                Debug.DrawRay(raycastObject.transform.position, transform.TransformDirection(Vector3.down) * 10f, Color.red);
            }
        }

        private void Raycast()
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5f, Color.blue);
        }

        public void OnTriggerEnter(Collider other)
        {
            var item = other.GetComponent<Item>();
            if (item)
            {
                inventory.AddItem(item.item, 1);
                Destroy(other.gameObject);
            }
        }

        private void OnApplicationQuit()
        {
            //inventory.Container.Clear();
        }
    }
}
