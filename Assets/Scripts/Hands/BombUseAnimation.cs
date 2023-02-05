using UnityEngine;

public class BombUseAnimation : MonoBehaviour,IHandsAnimation
{
    AnimationHelperMethods helperMethods;
    void Awake()
    {
        helperMethods = GetComponentInParent<AnimationHelperMethods>();    
    }
    public string AnimationStateToPlay => HandsAnimStates.GrenadeUse.ToString();

    public void AnimationPlay()
    {
        helperMethods.ChangeAnimationState(AnimationStateToPlay);
    }

}
