using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LockMouse : MonoBehaviour
{
    [ShowInInspector] [ReadOnly] private bool mouseLocked;

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if(Cursor.lockState == CursorLockMode.Locked) { mouseLocked = true; }
        else { mouseLocked = false; }
    }
}
