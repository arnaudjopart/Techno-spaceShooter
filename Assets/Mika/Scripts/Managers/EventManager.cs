using System;
using UnityEngine;

namespace Mika
{
    public static class EventManager
    {
        public static event Action<Enemy, bool> EnemyDeathEvent;
        public static event Action<int, int, int> PlayerLifeChangedEvent;
        public static event Action<WeaponData> PlayerChangeWeaponEvent;

        public static void InvokeEnemyDeathEvent(Enemy enemy, bool withReward)
        {
            EnemyDeathEvent?.Invoke(enemy, withReward);
        }

        public static void InvokePlayerLifeChangedEvent(int oldLife, int newLife, int maxLife)
        {
            PlayerLifeChangedEvent?.Invoke(oldLife, newLife, maxLife);
        }

        public static void InvokePlayerChangeWeaponEvent(WeaponData weaponData)
        {
            PlayerChangeWeaponEvent?.Invoke(weaponData);
        }
    }
}