using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerRemainingParts : MonoBehaviour
{
    public List<GameObject> towerPieces = new List<GameObject>();

    private void Awake() 
    {
        List<Transform> pieces = GetComponentsInChildren<Transform>().Where(t => (t.gameObject.tag == LevelOfDestruction.FirstDefender.ToString() || t.gameObject.tag == LevelOfDestruction.Destroyable.ToString() || t.gameObject.tag == LevelOfDestruction.Cannon.ToString())).ToList();
        towerPieces.Add(pieces[0].gameObject);
        towerPieces.Add(pieces[1].gameObject);
        towerPieces.Add(pieces[2].gameObject);
        towerPieces.Add(pieces[3].gameObject);
    }
}
