using UnityEngine;
public abstract class LongRangedWeapon : MonoBehaviour
{
    protected abstract void DebugMessage();
    protected abstract void ShotSound();
    protected abstract void ShotEffect();
    protected abstract void CameraShake();
    protected abstract void Shooting();
}
