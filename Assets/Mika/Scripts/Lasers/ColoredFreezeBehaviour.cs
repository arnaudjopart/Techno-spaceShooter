using System.Collections;
using UnityEngine;

namespace Mika
{
    public class ColoredFreezeBehaviour : ProjectileLogicBaseClass
    {
        [SerializeField] private float freezeTime = 5f;
        [SerializeField] private Color freezeColor;
        private WaitForSeconds waitFrozen;

        private void Start()
        {
            waitFrozen = new WaitForSeconds(freezeTime);
        }

        public override void ApplyEffect(Enemy _target)
        {
            StartCoroutine(ColoredFreeze(_target));
        }

        private IEnumerator ColoredFreeze(Enemy _target)
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Color c = _target.GetComponent<Renderer>().material.color;
            _target.GetComponent<Renderer>().material.color = freezeColor;
            _target.FreezeForSeconds(freezeTime);
            yield return waitFrozen;
            _target.GetComponent<Renderer>().material.color = c;
            Destroy(gameObject);
        }
    }
}