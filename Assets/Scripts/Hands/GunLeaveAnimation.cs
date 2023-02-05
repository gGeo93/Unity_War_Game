using UnityEngine;

public class GunLeaveAnimation : MonoBehaviour, IHandsAnimation
{
    AnimationHelperMethods helperMethods;
    
    public string AnimationStateToPlay => HandsAnimStates.GunLeave.ToString();

    void Awake() 
    {
        helperMethods = GetComponentInParent<AnimationHelperMethods>();
    }
    public void AnimationPlay()
    {
        helperMethods.ChangeAnimationState(AnimationStateToPlay);
    }
}
