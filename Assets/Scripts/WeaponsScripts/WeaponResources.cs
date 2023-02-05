using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponResources : MonoBehaviour, IResourcesDecreasing
{
    public Dictionary<WeaponType, int> WeaponsResources = new Dictionary<WeaponType, int>(){[WeaponType.BigGun] = 15, [WeaponType.RocketLauncher] = 3,[WeaponType.SmallGun] = 20,[WeaponType.Uzi] = 50, [WeaponType.Sniper] = 3, [WeaponType.Knife] = 100, [WeaponType.ClassicGrenade] = 11, [WeaponType.StunGrenade] = 16};
    WeaponChoice weaponChoice;
    private void Awake()
    {
        Events.OnUsingWeapon += ResourcesDecreased;
        Events.OnWeaponResourcesEnded = ResourcesChecked;
        Events.OnAmmoPickingUp += ResourcesIncreased;
    }    
    void Start()
    {
        weaponChoice = GetComponent<WeaponChoice>();
    }

    public void ResourcesDecreased(WeaponType weaponUsed)
    {
        if(WeaponsResources[weaponUsed] > 0)
        {
            WeaponsResources[weaponUsed] -= 1;
        }
    }
   
    void ResourcesIncreased(WeaponType weaponsAmmoKind, int ammo)
    {
        WeaponsResources[weaponsAmmoKind] += ammo;
    }
    
    void ResourcesChecked(WeaponType chosenWeapon)
    {
        if(WeaponsResources[chosenWeapon] == 0)
        {
            StartCoroutine(DelayWeaponDisable());    
        }
    }
    IEnumerator DelayWeaponDisable()
    {
        yield return new WaitForSeconds(1.5f);
        weaponChoice.ChosenWeapon.SetActive(false);
    }
}
