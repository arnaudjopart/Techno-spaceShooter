using UnityEngine;

public abstract class WeaponBase : ProjectileLogicBaseClass
{
    [SerializeField] protected float lifetimeMax = 2f;
    protected float Lifetime { get; private set; } = 0;

    protected virtual void Update()
    {
        this.Lifetime += Time.deltaTime;
        if (this.Lifetime > this.lifetimeMax)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ResetLifetime()
    {
        this.Lifetime = 0;
        this.Lifetime = 0;
    }
}
