using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class StunGrenadeActivation : FlyingWeapon
{
    Rigidbody rb;
    SphereCollider sphereCollider;
    Collider[] enemiesWithinRange;
    ParticleSystem grenadeExplosion;
    MeshRenderer[] grenadeMeshes;
    GrenadeGrab grenadeGrab;
    [SerializeField]private int temporaryStunGrenadeDamage = 1;
    
    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        grenadeExplosion = GetComponentInChildren<ParticleSystem>();
        grenadeMeshes = GetComponentsInChildren<MeshRenderer>();
        grenadeGrab = GetComponent<GrenadeGrab>();
    }
    protected override IEnumerator GrenadeActivation()
    {
        GetComponent<GrenadeThrow>().isHoldingGrenade = false;
        yield return new WaitForSeconds(2f);
        GetComponent<GrenadeThrow>().isHoldingGrenade = false;


        GrenadeExplosionSound();
        GrenadeExplosionEffect();
        
        rb.useGravity = false;
        rb.isKinematic = true;
        
        enemiesWithinRange = Physics.OverlapSphere(transform.position, 20f, 1 << 3);
        
        EnemiesInRange();
        
        for (var i = 0; i < grenadeMeshes.Length - 1; i++)
        {
            grenadeMeshes[i].enabled = false;
        }
                
        if(grenadeGrab != null)
            StartCoroutine(grenadeGrab.GrabNewGrenade());    
    }
    protected override void GrenadeExplosionEffect()
    {
        grenadeExplosion.Play();
    }
    protected override void GrenadeExplosionSound()
    {
        GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.grenadeGasSound);
    }
    protected override void HarmEnemiesInRange()
    {
        StartCoroutine(GradualDamage());
    }
    void EnemiesInRange()
    {
        if(enemiesWithinRange != null)
        {
            HarmEnemiesInRange();
        }
    }
    IEnumerator GradualDamage()
    {
        InvokeRepeating("HarmCausedAround", 0f , 0.1f);          
        yield return new WaitForSeconds(1.6f);
        CancelInvoke("HarmCausedAround");
        grenadeExplosion.Stop();
    }
    void HarmCausedAround()
    {
        foreach (var e in enemiesWithinRange)
        {
            if(enemiesWithinRange.All(col => col.enabled == false || col == null))
            {
                CancelInvoke("HarmCausedAround");
                break;
            }
            if(e != null)
            {
                e.GetComponent<IDamageable>().DamageCaused(temporaryStunGrenadeDamage);
            }
        }
    }
}
