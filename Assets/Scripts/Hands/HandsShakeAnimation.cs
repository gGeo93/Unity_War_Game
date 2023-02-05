using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsShakeAnimation : MonoBehaviour, IHandsAnimation
{
    AnimationHelperMethods animationHelperMethods;
    GrenadeThrow grenadeThrow;

    public string AnimationStateToPlay => HandsAnimStates.Shaking.ToString();
    
    private void Awake() 
    {
        animationHelperMethods = GetComponentInParent<AnimationHelperMethods>();
        grenadeThrow = GetComponentInChildren<GrenadeThrow>();
    }    

    public void AnimationPlay()
    {
        animationHelperMethods.ChangeAnimationLayerWeight(-1, 0.25f);
        animationHelperMethods.ChangeAnimationState(AnimationStateToPlay, -1);
    }

    private void BackgroundAnimWhenWalking()
    {
        if(( grenadeThrow == null || !grenadeThrow.isThrowingBomb) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            AnimationPlay();
        }
    }
    void Update()
    {
        BackgroundAnimWhenWalking();
    }

}
