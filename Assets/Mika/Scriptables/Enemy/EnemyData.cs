using UnityEngine;

[CreateAssetMenu(fileName = "enemy", menuName = "New Enemy", order = 51)]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    [Range(1, 100)]
    public int maxLives;
    public float maxLifetime;
    [Range(0f, 10f)]
    public float baseSpeed;
    [Range(1, 100)]
    public int points;
}
