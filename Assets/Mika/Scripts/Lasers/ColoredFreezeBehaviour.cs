using System.Collections;
using UnityEngine;

public class ColoredFreezeBehaviour : ProjectileLogicBaseClass
{
    [SerializeField] private float freezeTime = 5f;
    [SerializeField] private Color freezeColor;
    private WaitForSeconds waitFrozen;

    private void Start()
    {
        this.waitFrozen = new WaitForSeconds(freezeTime);
    }

    public override void ApplyEffect(EnemyBaseClass _target)
    {
        StartCoroutine(ColoredFreeze(_target));
    }

    private IEnumerator ColoredFreeze(EnemyBaseClass _target)
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Color c = _target.GetComponent<Renderer>().material.color;
        _target.GetComponent<Renderer>().material.color = this.freezeColor;
        _target.FreezeForSeconds(this.freezeTime);
        yield return waitFrozen;
        _target.GetComponent<Renderer>().material.color = c;
        Destroy(this.gameObject);
    }
}
