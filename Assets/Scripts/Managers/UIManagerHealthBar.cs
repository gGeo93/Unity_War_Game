using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerHealthBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] Slider healthBar;
    [SerializeField] TextMeshProUGUI gameOverMessage;
    [SerializeField] TextMeshProUGUI winningMessage;
    private bool IsHealthBarEmpty => healthBar.value == 0;
    private float maxHealth = 100f;
    
    void OnEnable()
    {
        hp.text = maxHealth.ToString();
        healthBar.value = maxHealth;

        winningMessage.gameObject.SetActive(false);
        gameOverMessage.gameObject.SetActive(false);
        Events.OnPlayerWinning += WinningMessage;
    }
    public void OnPlayerHarm(int harm)
    {
        if(healthBar.value > 0 && harm <= healthBar.value)
        {
            hp.text = (int.Parse(hp.text) - harm).ToString();
            healthBar.value -= harm;
        }
        if(IsHealthBarEmpty)
        {
            Invoke("QuitApp", 4f);
            Events.OnPlayerDying += GameOverMessage;
            GameManager.Instance.AudioManager.BackgroundSoundChange(GameManager.Instance.AudioManager.gameOverBackgroundSound, false);
            Events.OnPlayerDying?.Invoke();
            Events.OnPlayerDying = null;
        }
    }
    public void OnPlayerHeal(int heal)
    {
        if(healthBar.value <= maxHealth - heal)
        {
            hp.text = (int.Parse(hp.text) + heal).ToString();
            healthBar.value += heal;   
        }
        else if(healthBar.value > maxHealth - heal)
        {
            hp.text = "100";
            healthBar.value = 100;
        }
    }
    void GameOverMessage() => gameOverMessage.gameObject.SetActive(true);
    void WinningMessage() => winningMessage.gameObject.SetActive(true);
}
