using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeGrab : MonoBehaviour
{
    [SerializeField]Transform rightArm; 
    [SerializeField]Transform grenadeHolder;
    MeshRenderer[] grenadeMeshes;
    Rigidbody rb;
    StunGrenadeActivation stunGrenadeActivation;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grenadeMeshes = GetComponentsInChildren<MeshRenderer>();
        stunGrenadeActivation = GetComponent<StunGrenadeActivation>();
    }
    public IEnumerator GrabNewGrenade()
    {
        GetComponent<GrenadeThrow>().isHoldingGrenade = false;
        yield return new WaitForSeconds(4f);
        for (var i = 0; i < grenadeMeshes.Length - 1; i++)
        {
            grenadeMeshes[i].enabled = true;
        }
        transform.parent = rightArm;
        transform.position = grenadeHolder.position;
        Quaternion q = grenadeHolder.rotation;
        transform.rotation = q;
        rb.isKinematic = true; 
        rb.useGravity = false;
        stunGrenadeActivation.towerIsInRange = false;
        GetComponent<GrenadeThrow>().isHoldingGrenade = true;
    }
}
