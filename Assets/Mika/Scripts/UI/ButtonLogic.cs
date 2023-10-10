using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color hightlightColor;
    private TMP_Text text;
    private Color initialColor;

    private void Awake()
    {
        this.text = GetComponentInChildren<TMP_Text>();
        this.initialColor = this.text.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.text.color = this.hightlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.text.color = this.initialColor;
    }
}
