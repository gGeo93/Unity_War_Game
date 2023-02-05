using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManagerAttackingResourcesDisplay : MonoBehaviour
{
    Dictionary<WeaponType,TextMeshProUGUI> remainingResources = new Dictionary<WeaponType, TextMeshProUGUI>();
    [SerializeField]List<TextMeshProUGUI> remainingResourcesText;
    private void Awake() 
    {
        for (var i = 0; i < remainingResourcesText.Count; i++)
        {
            remainingResources[(WeaponType)i] = remainingResourcesText[i];
        }
        Events.OnUsingWeapon += UIResourcesReduced;
        Events.OnAmmoPickingUp += UIResourcesRaised;
    }
    void UIResourcesReduced(WeaponType typeOfResourcesToBeReduced)
    {
        int resources = int.Parse(remainingResources[typeOfResourcesToBeReduced].text.Substring(1));
        if(resources > 0)
        {
            resources -= 1;
            remainingResources[typeOfResourcesToBeReduced].text = 'x' + resources.ToString();        
        }
    }
    void UIResourcesRaised(WeaponType typeOfResourcesToBeRaised, int ammo)
    {
        int resources = int.Parse(remainingResources[typeOfResourcesToBeRaised].text.Substring(1)) + ammo;
        remainingResources[typeOfResourcesToBeRaised].text = 'x' + resources.ToString();
    }
    public void UIResourcesReduced(WeaponType weaponType, int ammoReduced)
    {
        int resources = int.Parse(remainingResources[weaponType].text.Substring(1));
        if (resources > 0)
        {
            resources -= ammoReduced;
            remainingResources[weaponType].text = 'x' + resources.ToString();
        }
    }
}
