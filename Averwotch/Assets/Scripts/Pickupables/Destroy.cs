using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Averwotch.Player.Globals;

public class Destroy : MonoBehaviour
{
    private void OnDestroy()
    {
        PlayerSettings._destroying = true;
    }
}
