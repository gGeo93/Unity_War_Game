using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttacking : MonoBehaviour
{
    TowerRemainingParts tower;
    public bool IsAttacking => tower.towerPieces.Count == 0;
    private void Awake() 
    {
        tower = GetComponentInParent<TowerRemainingParts>();
    }
}
