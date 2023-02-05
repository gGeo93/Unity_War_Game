using UnityEngine;

public class OnTakingTheAmmo : MonoBehaviour
{
    WeaponType randomAmmoTypePickUp;
    int numberOfWeapons = 8;
    void OnTriggerStay(Collider other) {
        if(other.CompareTag("Knife"))
        {
            randomAmmoTypePickUp = (WeaponType)RandomAmmo();
            int addedResources = AddedResourcesAccordingToTheWeapon(randomAmmoTypePickUp);
            Events.OnAmmoPickingUp?.Invoke(randomAmmoTypePickUp, addedResources);
            GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.pickUpPackage);
            Destroy(gameObject);
        }
    }
    int RandomAmmo()
    {
        int rn;
        while(true)
        {
            rn = UnityEngine.Random.Range(0,numberOfWeapons);
            if(rn != 5)
                break;
        }
        return rn;
    }
    int AddedResourcesAccordingToTheWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.BigGun: return 10;
            case WeaponType.RocketLauncher: return 3;
            case WeaponType.SmallGun: return 10;
            case WeaponType.Uzi: return 15;
            case WeaponType.Sniper: return 3;
            case WeaponType.ClassicGrenade: return 5;
            case WeaponType.StunGrenade: return 10;
            default: return -20;
        }
    }
}
