public class ShieldEndurance : EnduranceFunctionality, IDamageable
{
    public bool CanBeHurt => CanGetDamaged() == LevelOfDestruction.Destroyable.ToString();

    public bool CanBeDestroyed => hpBar.value <= 0;

    public void DamageCaused(int damage)
    {
        if(CanBeHurt) DamageTaken(damage);
        if(CanBeDestroyed) ToBeDestroyed();
    }

    protected override void ToBeDestroyed()
    {
        ToBeDestroyedSoundEffect();
        TowersRemainingDefendersMessages();
        RemoveDestroyedPartFromTheList();
        TowersRemainingDefendersMessages();
        RemoveHealthBarUponDestroy();
        DestroyThePart();    
    }
    protected override void ToBeDestroyedSoundEffect()
    {
        GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.towerShieldDestructionSound);
    }
}
