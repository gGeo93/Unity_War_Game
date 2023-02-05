using System.Collections;
using System.Linq;
using UnityEngine;

public class GrenadeExplosion : FlyingWeapon
{
    Rigidbody rb;
    Collider[] enemiesWithinRange;
    ParticleSystem grenadeExplosion;
    MeshRenderer[] grenadeMeshes;
    GrenadeGrab grenadeGrab;
    [SerializeField]private int classicGrenadeDamage = 15;
    
    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
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
        
        enemiesWithinRange = Physics.OverlapSphere(transform.position, 30f, 1 << 3);
        
        EnemiesInRange();
        
        for (var i = 0; i < grenadeMeshes.Length - 1; i++)
        {
            grenadeMeshes[i].enabled = false;
        }
        
        
        if(grenadeGrab != null)
            StartCoroutine(grenadeGrab.GrabNewGrenade());
    }
    protected override void GrenadeExplosionSound() => GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.grenadeExplosion);
    protected override void GrenadeExplosionEffect() => grenadeExplosion.Play();
    protected override void HarmEnemiesInRange()
    {
        foreach (var e in enemiesWithinRange)
        {
            if(enemiesWithinRange.All(col => col.enabled == false || col == null))
            {
                break;
            }
            if(e != null)
            {
                e.GetComponent<IDamageable>().DamageCaused(classicGrenadeDamage);
            }
        }
    }
    
    void EnemiesInRange()
    {
        if(enemiesWithinRange != null)
        {
            HarmEnemiesInRange();
        }
    }
}
