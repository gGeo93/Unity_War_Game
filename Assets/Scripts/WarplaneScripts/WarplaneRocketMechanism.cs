using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarplaneRocketMechanism : MonoBehaviour
{
    //Spawn
    //Travel
    //Collide
    public bool isSpawned;
    bool isShooting;
    [SerializeField] GameObject rocketPrefab;
    [SerializeField] Transform rocketSpawningPosition;
    GameObject rocketInstantiated;
    
    public void RocketSpawned()
    {
        if(isSpawned)
        {
            rocketInstantiated = Instantiate(rocketPrefab,rocketSpawningPosition.position,Quaternion.Euler(90,0,0));
            GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.bombFallingFromTheSkySound);
            isSpawned = false;
            isShooting = true;
        }
    }
    public void RocketTravell()
    {
        if(isShooting && !isSpawned && rocketInstantiated != null)
        {
            rocketInstantiated.GetComponent<Rigidbody>().AddForce(500f *  (GameManager.Instance.Fps.transform.position - rocketInstantiated.transform.position).normalized);
            isShooting = false;
        }
    }
}
