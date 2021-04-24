using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Averwotch.Player.Globals;
using Sirenix.OdinInspector;
using InControl;

namespace Averwotch.Player.Inventory
{
    public class PlayerInventory : MonoBehaviour
    {
        //Public Variables\\
        [Title("Strings", "", TitleAlignments.Centered)]
        [FoldoutGroup("Variable Checks", expanded: true)] [ShowOnly] public bool destroyed;
        [FoldoutGroup("Variable Checks", expanded: true)] [ShowOnly] public bool drop;
        [FoldoutGroup("Variable Checks", expanded: true)] [ShowOnly] public bool isWeaponActive;
        [FoldoutGroup("Variable Checks", expanded: true)] [ShowOnly] public string collidedWith;
        [FoldoutGroup("Variable Checks", expanded: true)] [ShowOnly] public string collidedTag;

        [Title("Game Objects", "", TitleAlignments.Centered)]
        [FoldoutGroup("Variable Checks", expanded: true)] [ShowOnly] public GameObject collided;
        [FoldoutGroup("Variable Checks", expanded: true)] [ShowOnly] public GameObject dropPos;
        [FoldoutGroup("Variable Checks", expanded: true)] [ShowOnly] public GameObject rifle;

        [Title("Inventory", "", TitleAlignments.Centered)]
        [FoldoutGroup("Inventory Array", expanded: true)] [ShowOnly] public int inventorySize;
        [FoldoutGroup("Inventory Array", expanded: true)] [ShowOnly] public int activeWeapon;
        [FoldoutGroup("Inventory Array", expanded: true)] [ShowOnly] public string weapon;
        [FoldoutGroup("Inventory Array", expanded: true)] [ShowOnly] public string[] inventory;
        //----------\\

        private void Start()
        {
        }

        private void Update()
        {
            if (inventory.Length < 1)
            {
                inventory = new string[inventorySize];
            }

            PlayerSettings._collidedWith = collidedWith;
            PlayerSettings._collidedTag = collidedTag;
            PlayerSettings._collided = collided;
            destroyed = PlayerSettings._destroying;
            inventorySize = PlayerSettings._invSize;
            drop = PlayerSettings._drop;
            activeWeapon = PlayerSettings._activeWeapon;
            PlayerSettings._isWeaponActive = isWeaponActive;
            rifle = PlayerSettings._rifle;
            dropPos = PlayerSettings._dropPosition;

            GODestroy();
            Pickup();
            Drop();

            if(inventory.Length >= 1)
            {
                ActiveWeapon();
            }
        }

        private void GODestroy()
        {
            if (destroyed)
            {
                collidedWith = null;
                collidedTag = null;
                collided = null;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            collidedWith = other.name;
            collidedTag = other.tag;
            collided = other.gameObject;
        }

        private void OnTriggerExit(Collider other)
        {
            collidedWith = null;
            collidedTag = null;
            collided = null;
        }

        private void Pickup()
        {
            if (PlayerSettings._weaponPickup)
            {
                if(inventory[0] == null)
                {
                    inventory[0] = collided.name;
                    Destroy(collided);
                }
                if (inventory[1] == null && inventory[0] != collided.name && inventory[2] != collided.name)
                {
                    inventory[1] = collided.name;
                    Destroy(collided);
                }
                if (inventory[2] == null && inventory[0] != collided.name && inventory[1] != collided.name)
                {
                    inventory[2] = collided.name;
                    Destroy(collided);
                }
                PlayerSettings._weaponPickup = false;
            }
        }

        private void Drop()
        {
            if (drop)
            {
                if (activeWeapon == 0)
                {
                    CheckWeapon();
                    inventory[0] = null;
                }
                if (activeWeapon == 1)
                {
                    inventory[1] = null;
                }
                if (activeWeapon == 2)
                {
                    inventory[2] = null;
                }
            }
        }

        private void CheckWeapon()
        {
            if (inventory[0] == "rifle")
            {
                Instantiate(rifle);
            }
        }

        private void ActiveWeapon()
        {
            if (activeWeapon == 0)
            {
                weapon = inventory[0];
                isWeaponActive = true;
            }
            if (activeWeapon == 1)
            {
                weapon = inventory[1];
                isWeaponActive = true;
            }
            if (activeWeapon == 2)
            {
                weapon = inventory[2];
                isWeaponActive = true;
            }

            if (weapon == null)
            {
                activeWeapon = -1;
                isWeaponActive = false;
            }
        }
    }
}
