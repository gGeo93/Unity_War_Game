using System.Collections.Generic;
using UnityEngine;

public class WeaponChoice : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();
    public GameObject ChosenWeapon {get; set;}
    public WeaponType ChosenType { get; set; }
    WeaponResources weaponResources;
    
    void Start()
    {
        weaponResources = GetComponent<WeaponResources>();
        ChosenType = WeaponType.BigGun;
        ChooseWeapon(WeaponType.BigGun);
        Events.OnPlayerDying += DeactivateCurrentWeapon;
    }
    public void ChooseWeapon(WeaponType weapon)
    {
        for (var i = 0; i < weapons.Count; i++)
        {
            if((int)weapon != i)
            {
                weapons[i].SetActive(false);
            }
            else if((int)weapon == i)
            {
                weapons[i].SetActive(true);
                ChosenWeapon = weapons[i];
                ChosenType = (WeaponType)i;
            }
        }
    }
    void DeactivateCurrentWeapon() => weapons.ForEach(go => go.SetActive(false));
    public void ChooseTheNextActiveWeapon(int indexOfActiveWeapon)
    {
        weapons[indexOfActiveWeapon].SetActive(true);
        ChosenWeapon = weapons[indexOfActiveWeapon];
        ChosenType = (WeaponType)indexOfActiveWeapon;
    }
}
