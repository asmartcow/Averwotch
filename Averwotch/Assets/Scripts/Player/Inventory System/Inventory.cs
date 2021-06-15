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
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int equipedAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int pistolAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int assaultRifleAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int machineGunAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int sniperRifleAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int rocketLauncherAmmo;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] [ReadOnly] private int shotgunAmmo;

    [Title("Prefab Settings", "", TitleAlignments.Centered)]
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public GameObject pistolPrefab;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public GameObject aRPrefab;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public GameObject mGPrefab;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public GameObject sniperPrefab;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public GameObject rLPrefab;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public GameObject shotgunPrefab;

    [Title("OBJ Settings", "", TitleAlignments.Centered)]
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public GameObject pistolObj;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public GameObject aRObj;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public GameObject mGObj;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public GameObject sniperObj;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public GameObject rLObj;
    [FoldoutGroup("ShowOnly")] [ShowInInspector] public GameObject shotgunObj;

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
        ca.drop.AddDefaultBinding(Key.Q);
    }

    private void Start()
    {
        currentIndex = 0;
    }

    private void Update()
    {
        if (collidedWith != null)
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

        if (ca.drop.WasPressed)
        {
            DropWeapon();
        }

        ShowCurrentWeaponInInspector();
        Equip();
    }

    private void Shoot()
    {
        if (currentWeapon == WeaponType.PISTOL)
        {

        }
        if (currentWeapon == WeaponType.ASSAULT_RIFLE)
        {
        }
        if (currentWeapon == WeaponType.MACHINE_GUN)
        {
        }
        if (currentWeapon == WeaponType.SNIPER_RIFLE)
        {
        }
        if (currentWeapon == WeaponType.ROCKET_LAUNCHER)
        {
        }
        if (currentWeapon == WeaponType.SHOTGUN)
        {
        }
        if (currentWeapon == WeaponType.NONE)
        {
        }
    }

    private void Equip()
    {
        if (currentWeapon == WeaponType.PISTOL)
        {
            pistolObj.SetActive(true);
            aRObj.SetActive(false);
            //mGObj.SetActive(false);
            sniperObj.SetActive(false);
            //shotgunObj.SetActive(false);
            //LObj.SetActive(false);
        }
        if (currentWeapon == WeaponType.ASSAULT_RIFLE)
        {
            pistolObj.SetActive(false);
            aRObj.SetActive(true);
            //mGObj.SetActive(false);
            sniperObj.SetActive(false);
            //shotgunObj.SetActive(false);
            //rLObj.SetActive(false);
        }
        if (currentWeapon == WeaponType.MACHINE_GUN)
        {
            //pistolObj.SetActive(false);
            //aRObj.SetActive(false);
            //mGObj.SetActive(true);
            //sniperObj.SetActive(false);
            //shotgunObj.SetActive(false);
            //rLObj.SetActive(false);
        }
        if (currentWeapon == WeaponType.SNIPER_RIFLE)
        {
            pistolObj.SetActive(false);
            aRObj.SetActive(false);
            //mGObj.SetActive(false);
            sniperObj.SetActive(true);
            //shotgunObj.SetActive(false);
            //rLObj.SetActive(false);
        }
        if (currentWeapon == WeaponType.ROCKET_LAUNCHER)
        {
            //pistolObj.SetActive(false);
            //aRObj.SetActive(false);
            //mGObj.SetActive(false);
            //sniperObj.SetActive(false);
            //shotgunObj.SetActive(false);
            //rLObj.SetActive(true);
        }
        if (currentWeapon == WeaponType.SHOTGUN)
        {
            //pistolObj.SetActive(false);
            //aRObj.SetActive(false);
            //mGObj.SetActive(false);
            //sniperObj.SetActive(false);
            //shotgunObj.SetActive(true);
            //rLObj.SetActive(false);
        }
        if (currentWeapon == WeaponType.NONE)
        {
            pistolObj.SetActive(false);
            aRObj.SetActive(false);
            //mGObj.SetActive(false);
            sniperObj.SetActive(false);
            //shotgunObj.SetActive(false);
            //rLObj.SetActive(false);
        }
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

                Destroy(collidedWith);
            }

            if (pistolAmmo >= maxPistolAmmo)
            {
                if (_weaponIndex0 != WeaponType.PISTOL || _weaponIndex1 != WeaponType.PISTOL)
                {
                    Destroy(collidedWith);
                }

                int toSubtract = pistolAmmo - maxPistolAmmo;
                pistolAmmo -= toSubtract;
            }
        }
        if (collidedWith.CompareTag("Assault Rifle"))
        {
            if (assaultRifleAmmo < maxAssaultRifleAmmo)
            {
                assaultRifleAmmo += assaultRifleClipSize;

                Destroy(collidedWith);
            }

            if (assaultRifleAmmo >= maxAssaultRifleAmmo)
            {
                if (_weaponIndex0 != WeaponType.ASSAULT_RIFLE || _weaponIndex1 != WeaponType.ASSAULT_RIFLE)
                {
                    Destroy(collidedWith);
                }

                int toSubtract = assaultRifleAmmo - maxAssaultRifleAmmo;
                assaultRifleAmmo -= toSubtract;
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

                if (_weaponIndex0 != WeaponType.MACHINE_GUN || _weaponIndex1 != WeaponType.MACHINE_GUN)
                {
                    Destroy(collidedWith);
                }
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
                if (_weaponIndex0 != WeaponType.SNIPER_RIFLE || _weaponIndex1 != WeaponType.SNIPER_RIFLE)
                {
                    Destroy(collidedWith);
                }

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
                if (_weaponIndex0 != WeaponType.ROCKET_LAUNCHER || _weaponIndex1 != WeaponType.ROCKET_LAUNCHER)
                {
                    Destroy(collidedWith);
                }

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
                if (_weaponIndex0 != WeaponType.SHOTGUN || _weaponIndex1 != WeaponType.SHOTGUN)
                {
                    Destroy(collidedWith);
                }

                int toSubtract = shotgunAmmo - maxShotgunAmmo;
                shotgunAmmo -= toSubtract;
            }
        }
    }

    private void SwapWeapon()
    {
        if (currentIndex == 0)
        {
            if (_weaponIndex0 != WeaponType.NONE)
            {
                if (_weaponIndex1 == WeaponType.NONE)
                {
                    weaponIndex[1] = (int)_weapon;
                    _weaponIndex1 = _weapon;
                    AddAmmo();
                }
                if (_weaponIndex1 != WeaponType.NONE)
                {
                    return;
                }
            }
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
            if (_weaponIndex1 != WeaponType.NONE)
            {
                if (_weaponIndex0 == WeaponType.NONE)
                {
                    weaponIndex[0] = (int)_weapon;
                    _weaponIndex0 = _weapon;
                    AddAmmo();
                }
                if (_weaponIndex0 != WeaponType.NONE)
                {
                    return;
                }
            }
            if (_weaponIndex0 == _weapon)
            {
                AddAmmo();
            }
            if (_weaponIndex0 != _weapon)
            {
                weaponIndex[1] = (int)_weapon;
                _weaponIndex1 = _weapon;
                AddAmmo();
            }
        }
    }

    private void DropWeapon()
    {
        var tempWep = WeaponType.NONE;
        if (currentIndex == 0)
        {
            tempWep = _weaponIndex0;
            _weaponIndex0 = WeaponType.NONE;
        }
        if (currentIndex == 1)
        {
            tempWep = _weaponIndex1;
            _weaponIndex1 = WeaponType.NONE;
        }

        if (tempWep == WeaponType.PISTOL)
        {
            Instantiate(pistolPrefab, (this.transform.position + new Vector3(0, 1, 0)), this.transform.rotation);
            pistolAmmo -= pistolClipSize;
        }
        if (tempWep == WeaponType.ASSAULT_RIFLE)
        {
            Instantiate(aRPrefab, (this.transform.position + new Vector3(0, 1, 0)), this.transform.rotation);
            assaultRifleAmmo -= assaultRifleClipSize;
        }
        if (tempWep == WeaponType.MACHINE_GUN)
        {
            Instantiate(mGPrefab, (this.transform.position + new Vector3(0, 1, 0)), this.transform.rotation);
            machineGunAmmo -= machineGunClipSize;
        }
        if (tempWep == WeaponType.SNIPER_RIFLE)
        {
            Instantiate(sniperPrefab, (this.transform.position + new Vector3(0, 1, 0)), this.transform.rotation);
            sniperRifleAmmo -= sniperRifleClipSize;
        }
        if (tempWep == WeaponType.ROCKET_LAUNCHER)
        {
            Instantiate(rLPrefab, (this.transform.position + new Vector3(0, 1, 0)), this.transform.rotation);
            sniperRifleAmmo -= sniperRifleClipSize;
        }
        if (tempWep == WeaponType.SHOTGUN)
        {
            Instantiate(shotgunPrefab, (this.transform.position + new Vector3(0, 1, 0)), this.transform.rotation);
            shotgunAmmo -= shotgunClipSize;
        }
    }

    private void ShowCurrentWeaponInInspector()
    {
        if (weaponIndex[0] == 0)
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