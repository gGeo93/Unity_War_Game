using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 playerOriginalPosition;
    Vector3 bulletsCanonPos;
    Rigidbody rb;
    ParticleSystem boom;
    
    private void OnEnable() {
        Destroy(gameObject, 10f);
        rb = GetComponent<Rigidbody>();
        boom = GetComponentInChildren<ParticleSystem>();
        GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.towerAttackSound);
        playerOriginalPosition = GameManager.Instance.Fps.transform.position + 0.25f * Vector3.up;
        bulletsCanonPos = transform.position;
    }
    void Update()
    {
        transform.Translate((playerOriginalPosition - bulletsCanonPos).normalized * 100f * Time.deltaTime);        
    }

    private void OnCollisionEnter(Collision other) {
        rb.velocity = Vector3.zero;
        boom.Play();
        if(other.collider.CompareTag("Player"))
        {
            other.collider.GetComponent<PlayerCollision>().PlayerGetsHurt();
            GameManager.Instance.HealthBarDisplay.OnPlayerHarm(5);
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
    }
}
