using UnityEngine;

public class BreakableAsteroid : DefaultAsteroid
{
    [SerializeField] private GameObject smallAsteroidPrefab;

    internal override void TakeDamage(int m_damagePoints)
    {
        // base.TakeDamage(m_damagePoints);
        if (--this.m_lives <= 0)
        {
            this.gameObject.SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                var o = Instantiate(this.smallAsteroidPrefab, this.transform.position, Quaternion.Euler(-Vector3.forward * Random.Range(0f, 360f)));
                o.transform.SetParent(this.transform.parent);
                o.GetComponent<Rigidbody2D>().AddForce(o.transform.up * 0.5f, ForceMode2D.Impulse);
            }
        }
    }
}
