using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Averwotch.Player.Globals;

namespace Averwotch.Player.Camera
{
    public class CameraLook : MonoBehaviour
    {
        //Private Variables\\
        private float c_Speed;
        private float yaw = 0.0f;
        private float pitch = 0.0f;
        //-----------------\\


        private void Update()
        {
            c_Speed = PlayerSettings._cameraSpeed;

            yaw += c_Speed * Input.GetAxis("Mouse X");
            pitch -= c_Speed * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
