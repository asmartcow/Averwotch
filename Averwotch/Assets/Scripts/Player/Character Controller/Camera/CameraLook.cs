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
        private float c_clampMin;
        private float c_clampMax;

        private bool m_lockMode;
        //-----------------\\


        private void Update()
        {
            c_Speed = PlayerSettings._cameraSpeed;
            c_clampMin = PlayerSettings._camClampMin;
            c_clampMax = PlayerSettings._camClampMax;
            m_lockMode = PlayerSettings._mouseLock;

            LookController();
            ControlMouseLock();
        }

        private void LookController()
        {
            yaw += c_Speed * Input.GetAxis("Mouse X");
            pitch -= c_Speed * Input.GetAxis("Mouse Y");

            pitch = Mathf.Clamp(pitch, c_clampMin, c_clampMax);

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }

        private void ControlMouseLock()
        {
            if (m_lockMode) { Cursor.lockState = CursorLockMode.Locked; }
            if (!m_lockMode) { Cursor.lockState = CursorLockMode.None; }
        }
    }
}
