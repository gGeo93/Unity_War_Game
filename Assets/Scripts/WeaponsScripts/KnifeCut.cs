using UnityEngine;

public class KnifeCut : MonoBehaviour
{
    [SerializeField]private int knifeCutDamage = 10;
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 3)
            other.GetComponent<IDamageable>().DamageCaused(knifeCutDamage);
    }
}
