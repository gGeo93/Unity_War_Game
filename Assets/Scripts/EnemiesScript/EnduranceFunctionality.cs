using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class EnduranceFunctionality : MonoBehaviour
{
   protected TowerRemainingParts towerRemainingParts;
   protected TextMeshProUGUI hpPoints;
   protected Slider hpBar;  
   
   private void Awake() 
   {
       towerRemainingParts = GetComponentInParent<TowerRemainingParts>();
       hpPoints = GetComponentInChildren<TextMeshProUGUI>();
       hpBar = GetComponentInChildren<Slider>();
   }
   
   protected void DamageTaken(int damage)
   {
        
        hpBar.value -= damage;
        hpPoints.text = (int.Parse(hpPoints.text) - damage).ToString();
    }
   
   protected string CanGetDamaged()
   {
        if(towerRemainingParts.towerPieces.Any(piece => piece.CompareTag(LevelOfDestruction.FirstDefender.ToString())))
        {
            return LevelOfDestruction.FirstDefender.ToString();
        }
        else if(towerRemainingParts.towerPieces.Any(piece => piece.CompareTag(LevelOfDestruction.Destroyable.ToString())))
        {
            return LevelOfDestruction.Destroyable.ToString();
        }
        else if(towerRemainingParts.towerPieces.Count > 0)       
        {
            return LevelOfDestruction.Cannon.ToString();
        }
        else
            return LevelOfDestruction.LastDefender.ToString();
   }
   protected abstract void ToBeDestroyed();
   protected abstract void ToBeDestroyedSoundEffect();
   protected virtual void TowersRemainingDefendersMessages() => Debug.Log("tower pieces: " + towerRemainingParts.towerPieces.Count);
   protected void RemoveDestroyedPartFromTheList() => towerRemainingParts.towerPieces.Remove(this.gameObject);
   protected void RemoveHealthBarUponDestroy()
   {
        hpBar.enabled = false;
        hpPoints.enabled = false;
   }
   protected void DestroyThePart() => Destroy(this.gameObject);
}
