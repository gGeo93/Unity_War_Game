using System.Collections;
using UnityEngine;

public class WeaponUse : MonoBehaviour
{
    WeaponChoice chosenWeaponScript;
    WeaponResources weaponResources;
    [SerializeField]SniperAimProcess sniperAimProcess;

    private void Awake() 
    {
        chosenWeaponScript = GetComponent<WeaponChoice>();
        weaponResources = GetComponent<WeaponResources>();    
    }
    void Update()
    {
        if(chosenWeaponScript.ChosenType == WeaponType.Sniper && Input.GetKeyDown(KeyCode.F))
        {
            sniperAimProcess.isScoped = !sniperAimProcess.isScoped;
            if(sniperAimProcess.isScoped) StartCoroutine(sniperAimProcess.OnScoped());
            else sniperAimProcess.OnUnScoped();
        }
        if(Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1) 
            && chosenWeaponScript.ChosenType != WeaponType.RocketLauncher 
            && chosenWeaponScript.ChosenType != WeaponType.ClassicGrenade 
            && chosenWeaponScript.ChosenType != WeaponType.StunGrenade
            && chosenWeaponScript.ChosenType != WeaponType.Uzi
            )
        {
            if(weaponResources.WeaponsResources[chosenWeaponScript.ChosenType] > 0)
            {
                Events.OnUsingWeapon?.Invoke(chosenWeaponScript.ChosenType);
                chosenWeaponScript.GetComponentInChildren<IWeaponUse>().WeaponUse();
                Events.OnWeaponResourcesEnded?.Invoke(chosenWeaponScript.ChosenType);
            }
        }
        if(Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1) && chosenWeaponScript.ChosenType == WeaponType.Uzi)
        {
            if(weaponResources.WeaponsResources[chosenWeaponScript.ChosenType] > 0)
            {
                chosenWeaponScript.GetComponentInChildren<IWeaponUse>().WeaponUse();
                Events.OnWeaponResourcesEnded?.Invoke(chosenWeaponScript.ChosenType);
            }
        }
    }
}
