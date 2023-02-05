using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        if(other.collider.CompareTag("Player"))
        {
            other.collider.GetComponent<PlayerCollision>().PlayerGetsHurt();
            GameManager.Instance.HealthBarDisplay.OnPlayerHarm(5);
            Destroy(this.gameObject, 0.5f);
        }    
    }
}
