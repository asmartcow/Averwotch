using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Averwotch.Player.Globals;

namespace Averwotch.Player.Camera
{
    public class CameraZoom: MonoBehaviour
    {
        private int activeWeapon;
        private bool isWeaponActive;
        private GameObject camOirinal;
        private GameObject camWeaponOut;
        private GameObject camPosition;

        private void Update()
        {
            activeWeapon = PlayerSettings._activeWeapon;
            isWeaponActive = PlayerSettings._isWeaponActive;
            camOirinal = PlayerSettings._camOriginal;
            camWeaponOut = PlayerSettings._camWeaponOut;
            camPosition = PlayerSettings._playerCamera;

            CameraPosition();
        }

        private void CameraPosition()
        {
            if (isWeaponActive)
            {
                camPosition.transform.position = Vector3.MoveTowards(camPosition.transform.position, camWeaponOut.transform.position, .1f);
            }
            if (!isWeaponActive)
            {
                camPosition.transform.position = Vector3.MoveTowards(camPosition.transform.position, camOirinal.transform.position, .1f);
            }
        }
    }
}