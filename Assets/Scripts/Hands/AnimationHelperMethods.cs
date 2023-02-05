using DG.Tweening;
using UnityEngine;

public class AnimationHelperMethods : MonoBehaviour
{
    Animator handsAnimator;
    
    private void Awake() 
    {
        handsAnimator = GetComponent<Animator>();    
    }
    public void ChangeAnimationState(string newState)
    {
        handsAnimator.Play(newState);
    }
    public void ChangeAnimationState(string newState, int layerIndex)
    {
        handsAnimator.Play(newState,layerIndex);
    }
    public void ChangeAnimationLayerWeight(int layerIndex, float layerWeight)
    {
        handsAnimator.SetLayerWeight(layerIndex, layerWeight);
    }
}
