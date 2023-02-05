using System.Collections;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour,IWeaponUse
{
    Animator animator;
    WeaponChoice chosenWeaponScript;
    BombUseAnimation bombUseAnimation;
    Rigidbody rb;
    SphereCollider sphereCollider;
    public bool isHoldingGrenade;
    public bool isThrowingBomb = true;

    private void OnEnable() 
    {
        isHoldingGrenade = true;
    }
    void Awake() 
    {
        animator = GetComponentInParent<Animator>();
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        bombUseAnimation = GetComponent<BombUseAnimation>();
        chosenWeaponScript = GetComponentInParent<WeaponChoice>();
    }
    void Start() 
    {
        rb.isKinematic = true; 
        rb.useGravity = false;   
    }
    void Update() 
    {
        if(Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1) 
            && isHoldingGrenade 
            && (chosenWeaponScript.ChosenType == WeaponType.ClassicGrenade
            || chosenWeaponScript.ChosenType == WeaponType.StunGrenade))
        {
            Events.OnUsingWeapon?.Invoke(chosenWeaponScript.ChosenType);
            WeaponUse();
            Events.OnWeaponResourcesEnded?.Invoke(chosenWeaponScript.ChosenType);
        }
    }
    public void WeaponUse()
    {
        if(isHoldingGrenade)
        {
            isHoldingGrenade = false;
            DebugMessage();
            GrenadeAnimation();
            StartCoroutine(GrenadeToBeThrown());
        }
    }
    void DebugMessage() => Debug.Log("Grenade throw!");
    void GrenadeAnimation() => bombUseAnimation.AnimationPlay();
    IEnumerator GrenadeToBeThrown()
    {
        isThrowingBomb = false;
        isHoldingGrenade = false;
        yield return new WaitForSeconds(1f);

        transform.parent = null;

        Vector3 grenadeDir = Camera.main.transform.forward;
        rb.isKinematic = false;
        rb.AddForce(1000f * grenadeDir);
        rb.useGravity = true;

        isHoldingGrenade = false;
        isThrowingBomb = true;
    }
}
