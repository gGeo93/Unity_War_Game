using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFirstDefenderOrbSpawner : MonoBehaviour
{
    [SerializeField]GameObject laserBeamPrefab;
    [SerializeField]Transform laserBeamSpawnSpot;
    int maximumNecessaryDistanceFromPlayer = 45;
    
    public void LaserBeamIsSpawned()
    {
        if
        (
            Vector3.Magnitude(GameManager.Instance.Fps.transform.position - laserBeamSpawnSpot.position) <= maximumNecessaryDistanceFromPlayer 
            &&
            !Events.OnStunGrenadeTrownNearEnemyTower.Invoke()
        )
        {
            Debug.Log("Orb Spawned");
            Instantiate(laserBeamPrefab, laserBeamSpawnSpot.position, Quaternion.identity);
        }
    }
}
