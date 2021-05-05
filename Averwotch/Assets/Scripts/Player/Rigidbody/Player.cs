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
        [FoldoutGroup("ShowOnly")][ShowInInspector][ReadOnly] private Rigidbody rb;

        [Title("Movement", "", TitleAlignments.Centered)]
        [FoldoutGroup("Variables")]public float speed;
        //\\

        //Private Variables\\
        private CharacterActions ca;
        //\\

        private void Awake()
        {
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
            //\\
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            Vector3 tempVector = new Vector3(ca.moveLR, 0, -ca.moveFB);
            tempVector = tempVector.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.localPosition + tempVector);
        }
    }
}
