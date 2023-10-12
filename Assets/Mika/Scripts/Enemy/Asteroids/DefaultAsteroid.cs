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
                if (!this.audioSource.isPlaying)
                {
                    this.audioSource.PlayOneShot(this.chocClip);
                }
                base.TakeDamage(m_damagePoints);
            }
        }
    }
}