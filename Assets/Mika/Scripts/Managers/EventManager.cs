using System;

namespace Mika
{
    public static class EventManager
    {
        public static event Action<Enemy> EnemyDeathEvent;
        public static event Action GameOverEvent;
        public static event Action<int, int, int> PlayerLostLifeEvent;
        public static event Action<WeaponType> PlayerChangeWeaponEvent;

        public static void InvokeEnemyDeathEvent(Enemy enemy)
        {
            EnemyDeathEvent?.Invoke(enemy);
        }

        public static void InvokeGameOverEvent()
        {
            GameOverEvent?.Invoke();
        }

        public static void InvokePlayerLifeChangedEvent(int oldLife, int newLife, int maxLife)
        {
            PlayerLostLifeEvent?.Invoke(oldLife, newLife, maxLife);
        }

        public static void InvokePlayerChangeWeaponEvent(WeaponType weaponType)
        {
            PlayerChangeWeaponEvent?.Invoke(weaponType);
        }
    }
}

public enum WeaponType
{
    LASER, BALL
}