using System;
public interface IGoblinDamageable : IDamageable
{
    EventHandler<bool> OnGoblinDying { get; set; }
}
