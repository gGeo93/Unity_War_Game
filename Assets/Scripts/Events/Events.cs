using System;

public class Events
{
     public static Action<WeaponType> OnUsingWeapon;
     public static Action<WeaponType> OnWeaponResourcesEnded;
     public static Action<WeaponType, int> OnAmmoPickingUp;
     public static Action OnPlayerDying;
     public static Action OnPlayerWinning;
     public static Action OnWarplaneStartTravelling;
     public static Func<bool> OnStunGrenadeTrownNearEnemyTower;
}
