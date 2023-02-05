using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowersLastDefenders : MonoBehaviour
{
    public List<GameObject> lastDefenders = new List<GameObject>();
    public bool ThereAreNoLastDefendersLeft => lastDefenders.Count == 0;
    
    void Awake() 
    {
        MatchingGoblinsToLastDefenders();
    }
    void MatchingGoblinsToLastDefenders()
    {
        List<Transform> goblins = GetComponentsInChildren<Transform>().Where(t => (t.gameObject.tag == LevelOfDestruction.LastDefender.ToString())).ToList();    
        for (var i = 0; i < goblins.Count; i++)
        {
            lastDefenders.Add(goblins[i].gameObject);
        }
    }
    public void GoblinDeath(GameObject deadGoblin)
    {
        lastDefenders.Remove(deadGoblin);
        if(ThereAreNoLastDefendersLeft)
        {
            Events.OnPlayerWinning.Invoke();
            Events.OnPlayerWinning = null;
        }
    }
}
