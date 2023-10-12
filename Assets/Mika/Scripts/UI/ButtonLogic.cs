using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mika
{
    public class ButtonLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Color hightlightColor;
        private TMP_Text text;
        private Color initialColor;

        private void Awake()
        {
            text = GetComponentInChildren<TMP_Text>();
            initialColor = text.color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            text.color = hightlightColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            text.color = initialColor;
        }
    }
}