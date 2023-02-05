using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoubleUziGuns : LongRangedWeapon, IWeaponUse
{
    WeaponResources weaponResources;
    AudioManager audioManager;
    Transform cameraPosition;
    bool canShoot = true;
    [SerializeField]private int uziSingleDamage = 5;
    [SerializeField]private int uziFirstDefenderSingleDamage = 18;
    [SerializeField]private int range = 40;
    [SerializeField]private GameObject rightHandUziWeapon;
    [SerializeField]private GameObject leftHandUziWeapon;
    [SerializeField]ParticleSystem rightHandUziShotEffec;
    [SerializeField]ParticleSystem leftHandUziShotEffec;
    public int timerInSeconds = 5;

    private void Awake() {
        audioManager = GameManager.Instance.AudioManager;
        weaponResources = GetComponentInParent<WeaponResources>();
    }
    private void OnEnable() {
        StartCoroutine(GrabBothWeapons());
    }
    private void OnDisable() {
        StopCoroutine(ShootingRepeatly());
    }
    private void Start() 
    {
        cameraPosition = GetComponentInParent<Camera>().gameObject.transform;
    }
    
    public void WeaponUse()
    {
        if(canShoot)
            StartCoroutine(ShootingRepeatly());
    }
    private IEnumerator GrabBothWeapons()
    {
        rightHandUziWeapon.SetActive(false);
        leftHandUziWeapon.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        rightHandUziWeapon.SetActive(true);
        leftHandUziWeapon.SetActive(true);
    }
    private IEnumerator ShootingRepeatly()
    {
        canShoot = false;
        InvokeRepeating("UziShootingProcess",0,0.2f);
        yield return new WaitForSeconds(0.8f);
        GameManager.Instance.AttackingResourcesDisplay.UIResourcesReduced(WeaponType.Uzi, 5);
        weaponResources.WeaponsResources[WeaponType.Uzi]-=5;
        Debug.Log(weaponResources.WeaponsResources[WeaponType.Uzi]);
        canShoot = true;
        CancelInvoke("UziShootingProcess");
    }
    private void UziShootingProcess()
    {
        DebugMessage();
        ShotSound();
        ShotEffect();     
        CameraShake();
        Shooting();
    }

    protected override void CameraShake()
    {
        cameraPosition.transform.DOShakePosition(0.25f, 0.5f);
    }

    protected override void DebugMessage()
    {
        Debug.Log("Uzi shooting!");
    }

    protected override void Shooting()
    {
        RaycastHit hit;
        if(Physics.Raycast(cameraPosition.position, cameraPosition.forward, out hit, range, 1<<3))
        {
            if(hit.collider.CompareTag("FirstDefender"))
            {
                hit.collider.GetComponent<IDamageable>().DamageCaused(uziFirstDefenderSingleDamage);
            }
            else
            {
                hit.collider.GetComponent<IDamageable>().DamageCaused(uziSingleDamage);
            }
        }    
    }

    protected override void ShotEffect()
    {
        audioManager.SoundToPlay(audioManager.uziSignleShotSound);
    }

    protected override void ShotSound()
    {
        rightHandUziShotEffec.Play();
        leftHandUziShotEffec.Play();
    }
}
