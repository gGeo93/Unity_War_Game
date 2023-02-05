using UnityEngine;

public class KnifeUseAnimation : MonoBehaviour, IHandsAnimation
{
    AnimationHelperMethods helperMethods;

    public string AnimationStateToPlay => HandsAnimStates.KnifeUse.ToString();

    void Awake() 
    {
        helperMethods = GetComponentInParent<AnimationHelperMethods>();
    }
    public void AnimationPlay()
    {
        helperMethods.ChangeAnimationState(AnimationStateToPlay);
    }
}
