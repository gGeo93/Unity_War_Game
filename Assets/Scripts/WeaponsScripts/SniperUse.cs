using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SniperUse : LongRangedWeapon, IWeaponUse
{
    GunUseAnimation gunUseAnimation;
    GunLeaveAnimation gunLeaveAnimation;
    SniperScopedAnimation sniperScopedAnimation;
    [SerializeField]private Camera sniperCam;
    [SerializeField]private int sniperShotDamage = 60;

    void Awake() 
    {
        gunUseAnimation = GetComponent<GunUseAnimation>();
        gunLeaveAnimation = GetComponent<GunLeaveAnimation>();
        sniperScopedAnimation = GetComponent<SniperScopedAnimation>();
    }
    void OnEnable() 
    {
        StartCoroutine(GrabGun());
    }
    void OnDisable() {
        gunLeaveAnimation.AnimationPlay();    
    }
    public void WeaponUse()
    {
        DebugMessage();
        ShotSound();
        ShotEffect();     
        CameraShake();
        Shooting();    
    }

    protected override void DebugMessage()
    {
        Debug.Log("Sniper Used!");
    }
    protected override void ShotSound()
    {
        GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.sniperShotSound);
    }
    protected override void ShotEffect()
    {
        sniperCam.DOShakePosition(0.2f,1f,5);
    }
    protected override void CameraShake()
    {
        transform.DOLocalMoveY(0.05f,0.2f);
    }
    protected override void Shooting()
    {
        RaycastHit hit;
        if(Physics.Raycast(sniperCam.transform.position, sniperCam.transform.forward, out hit, float.PositiveInfinity, 1<<10))
        {
            hit.collider.GetComponentInParent<GoblinHealthBar>().OnGoblinDying?.Invoke(this, true);
            hit.collider.GetComponentInParent<IDamageable>().DamageCaused(sniperShotDamage);
        }    
    }
    IEnumerator GrabGun()
    {
        yield return new WaitForSeconds(0.1f);
        gunUseAnimation.AnimationPlay();    
    }
}
