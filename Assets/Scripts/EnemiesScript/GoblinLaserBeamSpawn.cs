using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinLaserBeamSpawn : MonoBehaviour
{
    [SerializeField]GameObject laserBeamPrefab;
    [SerializeField]Transform laserBeamSpawnSpot;
    public void LaserBeamIsSpawned() => Instantiate(laserBeamPrefab, laserBeamSpawnSpot.position, Quaternion.identity);
}
