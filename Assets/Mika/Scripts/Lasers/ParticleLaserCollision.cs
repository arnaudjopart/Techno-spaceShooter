using UnityEngine;

public class ParticleLaserCollision : MonoBehaviour
{
    private ProjectileLogicBaseClass m_projectileLogic;

    void Start()
    {
        m_projectileLogic = GetComponent<ProjectileLogicBaseClass>();
    }

    private void OnParticleCollision(GameObject collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            m_projectileLogic.ApplyEffect(collision.GetComponent<Enemy>());
        }
    }
}
