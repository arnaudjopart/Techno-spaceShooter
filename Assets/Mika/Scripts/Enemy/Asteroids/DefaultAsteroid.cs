using UnityEngine;

namespace Mika
{
    public class DefaultAsteroid : Enemy
    {
        [SerializeField] private GameObject[] smallAsteroidPrefabs;
        [Range(0, 10)]
        [SerializeField] private int breakingParts = 0;
        [Range(0, 100)]
        [SerializeField] private int breakingChance = 0;

        internal override void TakeDamage(int m_damagePoints)
        {
            base.TakeDamage(m_damagePoints);
            if (m_lives <= 0)
            {
                gameObject.SetActive(false);
                if (this.smallAsteroidPrefabs.Length > 0 && this.breakingChance <= Random.Range(1, 101))
                {
                    for (int i = 0; i < this.breakingParts; i++)
                    {
                        var o = Instantiate(smallAsteroidPrefabs[Random.Range(0, this.smallAsteroidPrefabs.Length)], transform.position, Quaternion.Euler(-Vector3.forward * Random.Range(0f, 360f)));
                        o.transform.SetParent(transform.parent);
                        o.GetComponent<Rigidbody2D>().AddForce(o.transform.up * 0.5f, ForceMode2D.Impulse);
                    }
                }
            }
        }
    }
}