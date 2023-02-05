using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarplaneDirection : MonoBehaviour
{
    Vector3 startingPosition;
    float maxHeight;
    float initialDistanceFromPlayer;
    WarplaneRocketMechanism warplaneRocketMechanism;

    private void Awake() {
        warplaneRocketMechanism = GetComponent<WarplaneRocketMechanism>();
        Events.OnWarplaneStartTravelling = warplaneStartTravellingSound;
        Events.OnPlayerWinning += DestroyItsSelf;
    }

    void Start()
    {
        startingPosition = transform.position;
        maxHeight = transform.position.y;
        initialDistanceFromPlayer = Vector3.Magnitude(transform.position - new Vector3(GameManager.Instance.Fps.transform.position.x, maxHeight, GameManager.Instance.Fps.transform.position.z));
        GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.warplaneGettingCloserSound);
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(GameManager.Instance.Fps.transform.position.x,maxHeight,GameManager.Instance.Fps.transform.position.z), 100 * Time.deltaTime);
        transform.LookAt(GameManager.Instance.Fps.transform, Vector3.up);
        if(Mathf.Abs(transform.position.z - GameManager.Instance.Fps.transform.position.z)< 0.5f)
        {
            warplaneRocketMechanism.isSpawned = true;
            warplaneRocketMechanism.RocketSpawned();
            warplaneRocketMechanism.isSpawned = false;
            
            transform.position = startingPosition + Vector3.forward * initialDistanceFromPlayer;
            
            Events.OnWarplaneStartTravelling?.Invoke();
        }
        warplaneRocketMechanism.RocketTravell();
    }
    private void warplaneStartTravellingSound()
    {
        StartCoroutine(RestartFlying());
    }
    IEnumerator RestartFlying()
    {
        yield return new WaitForSeconds(4.25f);
        Debug.Log("Start flying towards player");
        GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.warplaneGettingCloserSound);
    }
    void DestroyItsSelf()
    {
        Destroy(this.gameObject);
    }
}
