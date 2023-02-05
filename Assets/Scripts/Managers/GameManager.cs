using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    
    [SerializeField] private UIManagerWeaponWheel uIManagerWeaponWheel;
    [SerializeField] private UiManagerAttackingResourcesDisplay attackingResourcesDisplay;
    [SerializeField] private UIManagerHealthBar uIManagerHealthBar;
    public UIManagerWeaponWheel UIWeaponWheelHandler => uIManagerWeaponWheel;
    public UiManagerAttackingResourcesDisplay AttackingResourcesDisplay => attackingResourcesDisplay;
    public UIManagerHealthBar HealthBarDisplay => uIManagerHealthBar;

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private FirstPersonController fps;
    
    public AudioManager AudioManager => audioManager;
    public FirstPersonController Fps => fps;
    
    void Awake() 
    {
        instance = this;
    }    
}
