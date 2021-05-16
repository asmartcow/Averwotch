using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using InControl;

public class Inventory : MonoBehaviour
{
    private enum WeaponType
    {
        NONE,
        PISTOL,
        ASSAULT_RIFLE,
        MACHINE_GUN,
        SNIPER_RIFLE,
        ROCKET_LAUNCHER,
        SHOTGUN
    };

    [Title("Weapon Inventory Info", "", TitleAlignments.Centered)]
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private WeaponType currentWeapon;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int currentIndex;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int[] weaponIndex = new int[2];
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private WeaponType _weapon;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private WeaponType _weaponIndex0;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private WeaponType _weaponIndex1;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private GameObject collidedWith;

    [Title("Current Ammo Amounts", "", TitleAlignments.Centered)]
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int pistolAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int assaultRifleAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int machineGunAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int sniperRifleAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int rocketLauncherAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int shotgunAmmo;

    [Title("Ammo Settings", "Pistol Settings", TitleAlignments.Centered)]
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public int maxPistolAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public int pistolClipSize;

    [Title("", "Assault Rifle Settings", TitleAlignments.Centered)]
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public int maxAssaultRifleAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public int assaultRifleClipSize;

    [Title("", "Machine Gun Settings", TitleAlignments.Centered)]
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public int maxMachineGunAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public int machineGunClipSize;

    [Title("", "Sniper Rifle Settings", TitleAlignments.Centered)]
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public int maxSniperRifleAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public int sniperRifleClipSize;

    [Title("", "Rocket Launcher Settings", TitleAlignments.Centered)]
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public int maxRocketLauncherAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public int rocketLauncherClipSize;

    [Title("", "Shotgun Settings", TitleAlignments.Centered)]
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public int maxShotgunAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public int shotgunClipSize;

    private CharacterActions ca;

    private void Awake()
    {
        ca = new CharacterActions();
        ca.use.AddDefaultBinding(Key.F);
        ca.nextWeapon.AddDefaultBinding(Key.Key1);
        ca.prevWeapon.AddDefaultBinding(Key.Key2);

        currentIndex = 0;
    }

    private void Update()
    {
        if(collidedWith != null)
        {
            if (ca.use.WasPressed)
            {
                SwapWeapon();
            }
        }

        if (ca.nextWeapon.WasPressed)
        {
            currentIndex = 0;
        }

        if (ca.prevWeapon.WasPressed)
        {
            currentIndex = 1;
        }

        ShowCurrentWeaponInInspector();
    }

    private void SetWeaponType()
    {
        if (collidedWith.CompareTag("Pistol"))
        {
            _weapon = WeaponType.PISTOL;
        }
        if (collidedWith.CompareTag("Assault Rifle"))
        {
            _weapon = WeaponType.ASSAULT_RIFLE;
        }
        if (collidedWith.CompareTag("Machine Gun"))
        {
            _weapon = WeaponType.MACHINE_GUN;
        }
        if (collidedWith.CompareTag("Sniper Rifle"))
        {
            _weapon = WeaponType.SNIPER_RIFLE;
        }
        if (collidedWith.CompareTag("Rocket Launcher"))
        {
            _weapon = WeaponType.ROCKET_LAUNCHER;
        }
        if (collidedWith.CompareTag("Shotgun"))
        {
            _weapon = WeaponType.SHOTGUN;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collidedWith = other.gameObject;
        SetWeaponType();
    }

    private void OnTriggerStay(Collider other)
    {
        collidedWith = other.gameObject;
        SetWeaponType();
    }

    private void OnTriggerExit(Collider other)
    {
        collidedWith = null;
        _weapon = WeaponType.NONE;
    }

    private void AddAmmo()
    {
        if (collidedWith.CompareTag("Pistol"))
        {
            if (pistolAmmo < maxPistolAmmo)
            {
                pistolAmmo += pistolClipSize;

                if (pistolAmmo >= maxPistolAmmo)
                {
                    int toSubtract = pistolAmmo - maxPistolAmmo;
                    pistolAmmo -= toSubtract;
                }

                Destroy(collidedWith);
            }
        }
        if (collidedWith.CompareTag("Assault Rifle"))
        {
            if (assaultRifleAmmo < maxAssaultRifleAmmo)
            {
                assaultRifleAmmo += assaultRifleClipSize;

                if (assaultRifleAmmo >= maxAssaultRifleAmmo)
                {
                    int toSubtract = assaultRifleAmmo - maxAssaultRifleAmmo;
                    assaultRifleAmmo -= toSubtract;
                }

                Destroy(collidedWith);
            }
        }
        if (collidedWith.CompareTag("Machine Gun"))
        {
            if (machineGunAmmo < maxMachineGunAmmo)
            {
                machineGunAmmo += machineGunClipSize;

                Destroy(collidedWith);
            }
            if (machineGunAmmo >= maxMachineGunAmmo)
            {
                int toSubtract = machineGunAmmo - maxMachineGunAmmo;
                machineGunAmmo -= toSubtract;
            }
        }
        if (collidedWith.CompareTag("Sniper Rifle"))
        {
            if (sniperRifleAmmo < maxSniperRifleAmmo)
            {
                sniperRifleAmmo += sniperRifleClipSize;

                Destroy(collidedWith);
            }
            if (sniperRifleAmmo >= maxSniperRifleAmmo)
            {
                int toSubtract = sniperRifleAmmo - maxSniperRifleAmmo;
                sniperRifleAmmo -= toSubtract;
            }
        }
        if (collidedWith.CompareTag("Rocket Launcher"))
        {
            if (rocketLauncherAmmo < maxRocketLauncherAmmo)
            {
                rocketLauncherAmmo += rocketLauncherClipSize;

                Destroy(collidedWith);
            }
            if (rocketLauncherAmmo >= maxRocketLauncherAmmo)
            {
                int toSubtract = rocketLauncherAmmo - maxRocketLauncherAmmo;
                rocketLauncherAmmo -= toSubtract;
            }
        }
        if (collidedWith.CompareTag("Shotgun"))
        {
            if (shotgunAmmo < maxShotgunAmmo)
            {
                shotgunAmmo += shotgunClipSize;

                Destroy(collidedWith);
            }
            if (shotgunAmmo >= maxShotgunAmmo)
            {
                int toSubtract = shotgunAmmo - maxShotgunAmmo;
                shotgunAmmo -= toSubtract;
            }
        }
    }

    private void SwapWeapon()
    {
        if(currentIndex == 0)
        {
            if (_weaponIndex1 == _weapon)
            {
                AddAmmo();
            }
            if (_weaponIndex1 != _weapon)
            {
                weaponIndex[0] = (int)_weapon;
                _weaponIndex0 = _weapon;
                AddAmmo();
            }
        }
        if (currentIndex == 1)
        {
            if(_weaponIndex0 == _weapon)
            {
                AddAmmo();
            }
            if(_weaponIndex0 != _weapon)
            {
                weaponIndex[1] = (int)_weapon;
                _weaponIndex1 = _weapon;
                AddAmmo();
            }
        }
    }

    private void ShowCurrentWeaponInInspector()
    {
        if(weaponIndex[0] == 0)
        {
            _weaponIndex0 = WeaponType.NONE;
        }
        if (weaponIndex[1] == 0)
        {
            _weaponIndex1 = WeaponType.NONE;
        }

        if (currentIndex == 0)
        {
            currentWeapon = _weaponIndex0;
        }
        if (currentIndex == 1)
        {
            currentWeapon = _weaponIndex1;
        }
    }
}
