using System.Collections;
using UnityEngine;

public class FreezeBehaviour : ProjectileLogicBaseClass
{
    [SerializeField] private float freezeTime = 5f;
    private Vector3 impactPos;

    public override void ApplyEffect(EnemyBaseClass _target)
    {
        StartCoroutine(Freeze(_target));
    }

    IEnumerator Freeze(EnemyBaseClass target)
    {
        GetComponent<Renderer>().enabled = false;
        //GetComponent<Collider>().enabled = false;
        float timer = this.freezeTime;
        impactPos = target.transform.position;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            target.transform.position = impactPos;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
