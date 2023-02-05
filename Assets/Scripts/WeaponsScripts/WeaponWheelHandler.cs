using System.Linq;
using UnityEngine;

public class WeaponWheelHandler : MonoBehaviour
{
    WeaponType currentWeaponType;
    UIManagerWeaponWheel uIManagerWeaponWheel;
    WeaponChoice weaponChoice;
    
    void Start()
    {
        uIManagerWeaponWheel = GameManager.Instance.UIWeaponWheelHandler;
        weaponChoice = GetComponent<WeaponChoice>();
        currentWeaponType = WeaponType.BigGun;
    }

    void Update()
    {
        if(Input.GetMouseButton(1) && (Events.OnPlayerDying != null))
        {
            uIManagerWeaponWheel.Wheel.SetActive(true);
            if (Input.GetAxis("Mouse ScrollWheel") > 0f )
            {
                if(currentWeaponType != WeaponType.StunGrenade)
                {
                    currentWeaponType += 1;
                    uIManagerWeaponWheel.ChangeWeapon((int)currentWeaponType - 1, (int)currentWeaponType);
                    
                }
                else
                {
                    currentWeaponType = WeaponType.BigGun;
                    uIManagerWeaponWheel.ChangeWeapon(7, (int)currentWeaponType);
                }
                weaponChoice.ChooseWeapon(currentWeaponType);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f )
            {
                if(currentWeaponType != WeaponType.BigGun)
                {    
                    currentWeaponType -= 1;
                    uIManagerWeaponWheel.ChangeWeapon((int)currentWeaponType + 1, (int)currentWeaponType);
                }
                else
                {
                    currentWeaponType = WeaponType.StunGrenade;
                    uIManagerWeaponWheel.ChangeWeapon(7, (int)currentWeaponType);
                }
                weaponChoice.ChooseWeapon(currentWeaponType);
            }
        }
        else if(Input.GetMouseButtonUp(1))
        {
            uIManagerWeaponWheel.Wheel.SetActive(false);
        }
    }
}
