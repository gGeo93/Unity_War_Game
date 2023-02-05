using UnityEngine;

public abstract class HandRangedWeapon : MonoBehaviour
{
    protected abstract void DebugMessage();
    protected abstract void WeaponSwingSound();
    protected abstract void WeaponSwingAnimation();
    protected bool canUseWeapon = true;
}
