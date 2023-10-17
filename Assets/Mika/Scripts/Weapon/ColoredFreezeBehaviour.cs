using System.Collections;
using UnityEngine;

namespace Mika
{
    public class ColoredFreezeBehaviour : WeaponBase
    {
        [SerializeField] private float freezeTime = 5f;
        [SerializeField] private Color freezeColor;
        private WaitForSeconds waitFrozen;

        private void Start()
        {
            waitFrozen = new WaitForSeconds(freezeTime);
        }

        public override void ApplyEffect(EnemyBaseClass _target)
        {
            StartCoroutine(ColoredFreeze(_target));
            this.gameObject.SetActive(false);
        }

        private IEnumerator ColoredFreeze(EnemyBaseClass _target)
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Color c = _target.GetComponent<Renderer>().material.color;
            _target.GetComponent<Renderer>().material.color = freezeColor;
            _target.FreezeForSeconds(freezeTime);
            yield return waitFrozen;
            _target.GetComponent<Renderer>().material.color = c;
        }
    }
}