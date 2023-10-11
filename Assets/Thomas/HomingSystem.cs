using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingSystem : MonoBehaviour
{
    IMovable movable;
    private EnemyBaseClass[] m_targets;

    private void Start()
    {
        movable = GetComponent<IMovable>();
        //m_targets = FindObjectsOfType<EnemyBaseClass>();
    }

    private void Update()
    {
        EnemyBaseClass selectedTarget = SelectTarget();
        if (selectedTarget != null)
        {
            ModifyAngle(selectedTarget);
            transform.position += transform.up * movable.Speed * Time.deltaTime;
        }
    }

    private EnemyBaseClass SelectTarget()
    {
        m_targets = FindObjectsOfType<EnemyBaseClass>();
        if (m_targets.Length == 0)
            return null;
        float posXProjectile = transform.position.x;
        float posYProjectile = transform.position.y;
        EnemyBaseClass selectedTarget = m_targets[0];
        float posXSelected = selectedTarget.GetComponent<Transform>().position.x;
        float posYSelected = selectedTarget.GetComponent<Transform>().position.y;
        float distanceSelected = Mathf.Sqrt((posXProjectile - posXSelected) * (posXProjectile - posXSelected) + (posYProjectile - posYSelected) * (posYProjectile - posYSelected));
        for(int i = 1; i < m_targets.Length; i++)
        {
            float newPosX = m_targets[i].GetComponent<Transform>().position.x;
            float newPosY = m_targets[i].GetComponent<Transform>().position.y;
            float newDistance = Mathf.Sqrt((posXProjectile - newPosX) * (posXProjectile - newPosX) + (posYProjectile - newPosY) * (posYProjectile - newPosY));
            if (distanceSelected > newDistance)
            {
                selectedTarget = m_targets[i];
                distanceSelected = newDistance;
            }
        }
        Debug.Log(selectedTarget.gameObject.name);
        return selectedTarget;
    }

    private void ModifyAngle(EnemyBaseClass target)
    {
        Vector3 directionTarget = new Vector3(target.GetComponent<Transform>().position.x - transform.position.x, target.GetComponent<Transform>().position.y - transform.position.y).normalized;
        float angle = Vector3.Angle(directionTarget, Vector3.up);
        if (target.GetComponent<Transform>().position.x < transform.position.x)
            angle = -angle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.GetComponent<EnemyBaseClass>() != null)
    //        m_targets = FindObjectsOfType<EnemyBaseClass>();
    //}
}