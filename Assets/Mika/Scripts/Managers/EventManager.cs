using System;

public static class EventManager
{
    public static event Action<Enemy> EnemyDeathEvent;
    public static event Action GameOverEvent;
    public static event Action<int, int> PlayerLostLifeEvent;

    public static void InvokeEnemyDeathEvent(Enemy enemy)
    {
        EnemyDeathEvent?.Invoke(enemy);
    }

    public static void InvokeGameOverEvent()
    {
        GameOverEvent?.Invoke();
    }

    public static void InvokePlayerLifeChangedEvent(int oldLife, int newLife)
    {
        PlayerLostLifeEvent?.Invoke(oldLife, newLife);
    }
}
