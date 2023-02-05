public interface IDamageable
{
    bool CanBeHurt { get; }
    bool CanBeDestroyed { get; }
    
    void DamageCaused(int damage);
}
