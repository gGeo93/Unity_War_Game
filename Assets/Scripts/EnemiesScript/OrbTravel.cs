using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTravel : MonoBehaviour
{
    [SerializeField]float speed = 50f;
    [SerializeField]float scale;
    Rigidbody orbRb;
    Vector3 direction;
    Camera playerCam;
    void Awake() 
    {
        orbRb = GetComponent<Rigidbody>();
        playerCam = Camera.main;
    }
    void Start()
    {
        Destroy(this.gameObject, 5f);
        GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.laserBeamSound);
        direction = (playerCam.transform.position - transform.position).normalized;
        transform.localScale = new Vector3(scale, scale, scale); 
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
