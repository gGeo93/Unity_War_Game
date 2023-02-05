using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLocator : MonoBehaviour
{
    private Transform bulletPos;
    public Transform mainCamera;
    public Transform damageLocator;
    
    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Cannon Ball"))
        {
            damageLocator.gameObject.SetActive(true);
            StartCoroutine(DamageIndicatorDuration());

            bulletPos = other.collider.GetComponent<Bullet>().transform;
            
            Vector3 bulletRelativePos = new Vector3(bulletPos.position.x, mainCamera.position.y, bulletPos.position.z);
            Vector3 bullet2camera = bulletRelativePos - mainCamera.position;

            Vector3 bulletLocalPos = mainCamera.InverseTransformPoint(bulletRelativePos);
            
            float dot = Vector3.Dot(mainCamera.forward, bullet2camera.normalized);
            
            float rot = remap(dot,-1f,1f,-90f,90f);
            
            if (bulletLocalPos.x > 0 && bulletLocalPos.z > 0)
            {
                damageLocator.localEulerAngles = new Vector3(0f, 0f, -rot);
            }
            else if (bulletLocalPos.x < 0 && bulletLocalPos.z >0) 
            {
                damageLocator.localEulerAngles = new Vector3(0f, 0f, rot);
            }
            else if (bulletLocalPos.x > 0 && bulletLocalPos.z < 0) 
            {
                damageLocator.localEulerAngles = new Vector3(0f, 0f, rot);
            }
            else if (bulletLocalPos.x < 0 && bulletLocalPos.z < 0) 
            {
                damageLocator.localEulerAngles = new Vector3(0f, 0f, -rot);
            }
        }
    }
    IEnumerator DamageIndicatorDuration()
    {
        yield return new WaitForSeconds(2.5f);
        damageLocator.gameObject.SetActive(false);
    }
    float remap(float val, float in1, float in2, float out1, float out2)
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
}
