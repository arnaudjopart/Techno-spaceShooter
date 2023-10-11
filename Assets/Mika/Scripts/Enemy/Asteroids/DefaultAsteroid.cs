using UnityEngine;

namespace Mika
{
    public class DefaultAsteroid : Enemy
    {
        [SerializeField] private AudioClip chocClip;

        internal override void TakeDamage(int m_damagePoints)
        {
            if (IsAlive)
            {
                this.audioSource.PlayOneShot(this.chocClip);
                base.TakeDamage(m_damagePoints);
            }
        }
    }
}