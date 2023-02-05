using UnityEngine;

public class SniperScopedAnimation : MonoBehaviour, IHandsAnimation
{
    AnimationHelperMethods helperMethods;
    
    public string AnimationStateToPlay => HandsAnimStates.SniperScoped.ToString();

    void Awake() 
    {
        helperMethods = GetComponentInParent<AnimationHelperMethods>();
    }
    public void AnimationPlay()
    {
        helperMethods.ChangeAnimationState(AnimationStateToPlay);
    }
    public void SetHandsShaking(int layerIndex, float layerWeight)
    {
        helperMethods.ChangeAnimationLayerWeight(layerIndex, layerWeight);
    }
}