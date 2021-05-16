using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LockMouse : MonoBehaviour
{
    [ShowInInspector] public bool lockMouse;

    void Update()
    {
        MouseLock();
    }

    public void MouseLock()
    {
        if (lockMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (!lockMouse)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
