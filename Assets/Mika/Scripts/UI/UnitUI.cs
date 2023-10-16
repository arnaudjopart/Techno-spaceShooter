using UnityEngine;
using UnityEngine.UI;

namespace Mika
{
    [DefaultExecutionOrder(1000)]
    public class UnitUI : MonoBehaviour
    {
        [SerializeField] private Image lifeBar;
        [SerializeField] private Gradient colorGradient;

        public void UpdateLifeBar(int life, int maxLife)
        {
            float ratio = life / (float)maxLife;
            this.lifeBar.color = this.colorGradient.Evaluate(ratio);
            this.lifeBar.fillAmount = ratio;
        }

        private void LateUpdate()
        {
            this.transform.rotation = Camera.main.transform.rotation;
        }
    }
}