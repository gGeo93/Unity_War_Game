using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAimProcess : MonoBehaviour
{
    SniperScopedAnimation scopedAnimation;
    GunUseAnimation gunUseAnimation;
    [SerializeField]private Camera sniperCam;
    [SerializeField]private GameObject normalCrosshair;
    [SerializeField]private GameObject sniperRifleCrosshair;
    [SerializeField]private float sniperFieldOfView = 27;
    public bool isScoped;
    void Awake() 
    {
        isScoped = false;
        scopedAnimation = GetComponent<SniperScopedAnimation>();
        gunUseAnimation = GetComponent<GunUseAnimation>();
    }
    public IEnumerator OnScoped()
    {
        normalCrosshair.SetActive(false);
        SetHandsShaking(-1, 0);
        AimTransition();
        sniperCam.fieldOfView = sniperFieldOfView;
        yield return new WaitForSeconds(.5f);
        sniperCam.gameObject.SetActive(true);
        sniperRifleCrosshair.SetActive(true);
        sniperCam.fieldOfView = Mathf.Lerp(27f, 7.5f, 1f);
    }
    public void OnUnScoped()
    {
        normalCrosshair.SetActive(true);
        sniperRifleCrosshair.SetActive(false);
        sniperCam.gameObject.SetActive(false);
        gunUseAnimation.AnimationPlay();
    }
    
    private void SetHandsShaking(int layerIndex, float layerWeight)
    {
        scopedAnimation.SetHandsShaking(-1, 0);
    }
    private void AimTransition()
    {
        scopedAnimation.AnimationPlay();
    }
}
