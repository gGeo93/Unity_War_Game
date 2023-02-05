using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFirstDefenderAttacking : MonoBehaviour
{
    TowerFirstDefenderOrbSpawner spawner;
    [SerializeField] private float attackingRate = 3;
    private float timer = 0;
    void Start()
    {
        spawner = GetComponent<TowerFirstDefenderOrbSpawner>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer >= attackingRate)
        {
            timer = 0f;
            spawner.LaserBeamIsSpawned();
        }
    }
}
