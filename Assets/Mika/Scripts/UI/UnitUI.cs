using UnityEngine;
using UnityEngine.UI;

namespace Mika
{
    public class UnitUI : MonoBehaviour
    {
        [SerializeField] private Image lifeBar;
        [SerializeField] private Gradient colorGradient;
        private Enemy parent;

        private void Awake()
        {
            this.parent = this.transform.parent.GetComponent<Enemy>();
            UpdateLifeBar(1f);
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
            UpdateLifeBar(newLife / (float)maxLife);
        }

        private void UpdateLifeBar(float ratio)
        {
            this.lifeBar.color = this.colorGradient.Evaluate(ratio);
            this.lifeBar.fillAmount = ratio;
        }
    }
}