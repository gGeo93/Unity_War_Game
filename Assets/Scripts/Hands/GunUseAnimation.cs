using UnityEngine;

public class GunUseAnimation : MonoBehaviour, IHandsAnimation
{
    AnimationHelperMethods helperMethods;
    
    public string AnimationStateToPlay => HandsAnimStates.GunGrab.ToString();

    void Awake() 
    {
        helperMethods = GetComponentInParent<AnimationHelperMethods>();
    }
    public void AnimationPlay()
    {
        helperMethods.ChangeAnimationState(AnimationStateToPlay);
    }
}
