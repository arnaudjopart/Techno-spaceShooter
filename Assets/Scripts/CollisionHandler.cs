
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private ProjectileLogicBaseClass m_projectileLogic;

    // Start is called before the first frame update
    void Start()
    {
        m_projectileLogic = GetComponent<ProjectileLogicBaseClass>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EnemyBaseClass>() != null) 
        {
            m_projectileLogic.ApplyEffect(collision.GetComponent<EnemyBaseClass>());
        }
    }
}
