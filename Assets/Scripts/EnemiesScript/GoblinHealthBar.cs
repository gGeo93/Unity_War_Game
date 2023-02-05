using System;
using UnityEngine;
public class GoblinHealthBar : EnduranceFunctionality, IGoblinDamageable
{
    public EventHandler<bool> OnGoblinDying { get; set;}

    bool getsHeadshot;

    public bool CanBeHurt => CanGetDamaged() == LevelOfDestruction.LastDefender.ToString() || getsHeadshot;

    public bool CanBeDestroyed => hpBar.value <= 0;


    private void OnEnable() {
        OnGoblinDying += On_GoblingDying;
    }

    public void DamageCaused(int damage)
    {
        if(CanBeHurt) DamageTaken(damage);
        if(CanBeDestroyed) OnGoblinDying?.Invoke(this, true);    
    }

    protected override void ToBeDestroyed()
    {
        ToBeDestroyedSoundEffect();
        RemoveHealthBarUponDestroy();
        TowersRemainingDefendersMessages();
    }
    protected override void ToBeDestroyedSoundEffect()
    {
        GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.GoblinDyingSound);    
    }
    protected override void TowersRemainingDefendersMessages()
    {
        Debug.Log("Last Defender is dead!");
    }
    void On_GoblingDying(object sender, bool e)
    {
        if(e)
        {
            getsHeadshot = true;
        }
        if(CanBeDestroyed) 
        {
            GetComponent<Collider>().enabled = false;
            ToBeDestroyed();
        }
    }
}
