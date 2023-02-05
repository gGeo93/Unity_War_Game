using UnityEngine;

public class OnTakingFirstAidKit : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Knife"))
        {
            GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.pickUpPackage);
            GameManager.Instance.HealthBarDisplay.OnPlayerHeal(30);
            Destroy(gameObject);
        }    
    }
}
