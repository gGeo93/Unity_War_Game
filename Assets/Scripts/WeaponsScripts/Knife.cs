using UnityEngine;

public class Knife : HandRangedWeapon,IWeaponUse
{
    Animator animator;
    KnifeUseAnimation knifeUseAnimation;
    void Awake() 
    {
        animator = GetComponentInParent<Animator>();
        knifeUseAnimation = GetComponent<KnifeUseAnimation>();
    }
    public void WeaponUse()
    {
        DebugMessage();
        WeaponSwingSound();
        WeaponSwingAnimation();
    }
    protected override void DebugMessage() => Debug.Log("Knife use!");
    protected override void WeaponSwingSound() => GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.knifeSwingSound);
    protected override void WeaponSwingAnimation() => knifeUseAnimation.AnimationPlay();
}
