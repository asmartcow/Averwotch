using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.vItemManager;

public class InventorySystem : MonoBehaviour
{
    public bool enableDebug;
    
    public vItemManager itemManager;

    private void OnEnable()
    {
        if (enableDebug)
        {
            Debug.Log("Initializing:");
        }
        if (itemManager == null)
        {
            if (enableDebug)
            {
                Debug.Log("=-=-= Initializing Item Manager =-=-=");
            }
            itemManager = GetComponentInParent<vItemManager>();
            if (enableDebug)
            {
                Debug.Log("Item Manager successfully added!");
            }
        }
    }

    public void Debugging()
    {
        Debug.Log("Action Succeeded!");
    }

    public void OnWeaponPickup()
    {
        if (enableDebug)
        {
            Debug.Log("Picking up a weapon!");
        }
        itemManager.AddItem();
    }
}
