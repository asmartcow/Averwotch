using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Averwotch.Player.Globals;

namespace Averwotch.Player.Camera
{
    public class FollowPlayer : MonoBehaviour
    {

        //Variables\\
        private float smoothTime = .1f;

        private Vector3 velocity = Vector3.zero;

        private GameObject followObject;
        //-----------------\\

        private void Update()
        {
            smoothTime = PlayerSettings._smoothTime;
            followObject = PlayerSettings._followObject;

            transform.position = Vector3.SmoothDamp(transform.position, followObject.transform.position, ref velocity, smoothTime);
        }
    }
}
