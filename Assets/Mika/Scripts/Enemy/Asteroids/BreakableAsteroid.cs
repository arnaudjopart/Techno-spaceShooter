using UnityEngine;

namespace Mika
{
    public class BreakableAsteroid : DefaultAsteroid
    {
        [SerializeField] private GameObject smallAsteroidPrefab;

        internal override void TakeDamage(int m_damagePoints)
        {
            // base.TakeDamage(m_damagePoints);
            if (--m_lives <= 0)
            {
                gameObject.SetActive(false);
                for (int i = 0; i < 3; i++)
                {
                    var o = Instantiate(smallAsteroidPrefab, transform.position, Quaternion.Euler(-Vector3.forward * Random.Range(0f, 360f)));
                    o.transform.SetParent(transform.parent);
                    o.GetComponent<Rigidbody2D>().AddForce(o.transform.up * 0.5f, ForceMode2D.Impulse);
                }
            }
        }
    }
}