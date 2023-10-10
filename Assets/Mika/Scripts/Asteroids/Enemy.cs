using UnityEngine;

public class Enemy : EnemyBaseClass
{
    [SerializeField] private float maxLifeTime = 20f;
    private float lifeTime = 0f;
    [Range(1, 100)]
    [SerializeField] private int points = 1;

    private void Start()
    {
        this.m_lives = Mathf.Max(1, this.m_lives);
        this.lifeTime = 0f;
    }

    internal override void TakeDamage(int m_damagePoints)
    {
        base.TakeDamage(m_damagePoints);
        if (m_lives <= 0)
        {
            EventManager.InvokeEnemyDeathEvent(this);
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (this.m_lives <= 0)
        {
            return;
        }
        // désactivé après 5s
        this.lifeTime += Time.deltaTime;
        if (this.lifeTime > this.maxLifeTime)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ResetLifetime()
    {
        this.lifeTime = 0f;
    }

    public virtual int GetPointValue()
    {
        return this.points;
    }
}
