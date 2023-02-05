using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeGrab : MonoBehaviour
{
    [SerializeField]Transform rightArm; 
    [SerializeField]Transform grenadeHolder;
    MeshRenderer[] grenadeMeshes;
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grenadeMeshes = GetComponentsInChildren<MeshRenderer>();
    }
    public IEnumerator GrabNewGrenade()
    {
        GetComponent<GrenadeThrow>().isHoldingGrenade = false;
        yield return new WaitForSeconds(1.5f);
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
        GetComponent<GrenadeThrow>().isHoldingGrenade = true;
    }
}
