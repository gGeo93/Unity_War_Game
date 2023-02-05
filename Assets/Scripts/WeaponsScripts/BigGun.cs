using System.Collections;
using UnityEngine;
using DG.Tweening;

public class BigGun : LongRangedWeapon,IWeaponUse
{
    GunUseAnimation gunGrabAnimation;
    GunLeaveAnimation gunLeaveAnimation;
    ParticleSystem bigGunShotEffect;
    Transform cameraPosition;
    [SerializeField] private int bigGunDamage = 30;
    int range = 50;

    private void Awake() {
        gunGrabAnimation = GetComponent<GunUseAnimation>();
        gunLeaveAnimation = GetComponent<GunLeaveAnimation>();
    }
    private void OnEnable() 
    {
        StartCoroutine(GrabOrLeaveGun());
    }
    private void OnDisable() {
        gunLeaveAnimation.AnimationPlay();            
    }
    void Start() {
        cameraPosition = GetComponentInParent<Camera>().gameObject.transform;    
        bigGunShotEffect = GetComponentInChildren<ParticleSystem>();
    }
    public void WeaponUse()
    {
        BigGunShootingProcess();
    }
    void BigGunShootingProcess()
    {
        DebugMessage();
        ShotSound();
        ShotEffect();     
        CameraShake();
        Shooting();
    }
    protected override void DebugMessage() =>  Debug.Log("Big Gun Shoot!");
    protected override void ShotSound() => GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.bigGunShotSound);
    protected override void ShotEffect() => bigGunShotEffect.Play();
    protected override void CameraShake() => cameraPosition.transform.DOShakePosition(0.5f);
    protected override void Shooting()
    {
        RaycastHit hit;
        if(Physics.Raycast(cameraPosition.position, cameraPosition.forward, out hit, range, 1<<3))
        {
            hit.collider.GetComponent<IDamageable>().DamageCaused(bigGunDamage);
        }
    }
    IEnumerator GrabOrLeaveGun()
    {
        yield return new WaitForSeconds(0.1f);
        gunGrabAnimation.AnimationPlay();    
    }
}
