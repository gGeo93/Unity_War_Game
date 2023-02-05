using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip winningBackgroundSound;
    public AudioClip gameOverBackgroundSound;
    public AudioClip warplaneGettingCloserSound;
    public AudioClip bombFallingFromTheSkySound;
    public AudioClip playerGetsHurt;
    public AudioClip playerDiesSound;
    public AudioClip bigGunShotSound;
    public AudioClip smallGunShotSound;
    public AudioClip uziSignleShotSound;
    public AudioClip sniperShotSound;
    public AudioClip knifeSwingSound;
    public AudioClip grenadeExplosion;
    public AudioClip grenadeGasSound;
    public AudioClip towerAttackSound;
    public AudioClip towerFirstDefenderDestroyedSound;
    public AudioClip towerShieldDestructionSound;
    public AudioClip towerCannonDestroyedSound;
    public AudioClip towerBaseCompletelyDestruction;
    public AudioClip GoblinDyingSound;
    public AudioClip laserBeamSound;
    public AudioClip pickUpPackage;
    AudioSource audioSource;
    void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
        Events.OnPlayerWinning += WinningSound;
    }
    public void BackgroundSoundChange(AudioClip backgroundAudio, bool isLooping)
    {
        audioSource.clip = backgroundAudio;
        audioSource.loop = isLooping;
        audioSource.Play();
    }
    public void SoundToPlay(AudioClip audioToPlay)
    {
        audioSource.PlayOneShot(audioToPlay);
    }
    void WinningSound()
    {
        audioSource.clip = winningBackgroundSound;
        audioSource.loop = true;
        audioSource.Play();
    }
}
