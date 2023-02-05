using UnityEngine;
using System.Collections;


public abstract class FlyingWeapon : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Ground"))
        {
            StartCoroutine(GrenadeActivation());
        }
    }
    protected abstract IEnumerator GrenadeActivation();
    protected abstract void GrenadeExplosionSound();
    protected abstract void GrenadeExplosionEffect();
    protected abstract void HarmEnemiesInRange();
}
