using UnityEngine;
using UnityEngine.UI;

namespace Mika
{
    public class UnitUI : MonoBehaviour
    {
        [SerializeField] private Image lifeBar;
        private Enemy parent;

        private void Awake()
        {
            this.parent = this.transform.parent.GetComponent<Enemy>();
        }

        private void OnEnable()
        {
            this.parent.EnemyLifeChangedEvent += OnLifeChanged;
        }

        private void OnDisable()
        {
            this.parent.EnemyLifeChangedEvent -= OnLifeChanged;
        }

        private void OnLifeChanged(int oldLife, int newLife, int maxLife)
        {
            this.lifeBar.fillAmount = newLife / (float)maxLife;
        }
    }
}