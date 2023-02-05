using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerWeaponWheel : MonoBehaviour
{
    public GameObject Wheel;
    [SerializeField]List<Image> displayedWeapons;
    List<Color> weaponBackgroundColors = new List<Color>();
    [SerializeField]Image currentWeaponImg;
    Image previousWeaponImg;
    
    private void Awake() {
        for (var i = 0; i < displayedWeapons.Count; i++)
        {
            weaponBackgroundColors.Add(displayedWeapons[i].color);
        }
        
    }
    private void Start() 
    {
        Wheel.SetActive(false);
        currentWeaponImg = displayedWeapons[0];
        currentWeaponImg.color = new Color(0.5f, 0.5f, 0.5f, 0.75f);
    }
    public void ChangeWeapon(int oldIndex, int newIndex)
    {   
        currentWeaponImg = displayedWeapons[newIndex];
        
        displayedWeapons[oldIndex].color = weaponBackgroundColors[oldIndex];
        displayedWeapons[newIndex].color = new Color(0.5f, 0.5f, 0.5f, 0.75f);
        currentWeaponImg.color = new Color(0.5f, 0.5f, 0.5f, 0.75f);
    }
    public void WeaponDisplayDisabled() => currentWeaponImg.GetComponentInChildren<Image>().enabled = false;
    
    void WeaponDisplayReEnabled() => currentWeaponImg.GetComponentInChildren<Image>().enabled = true;
}
