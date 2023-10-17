using Mika;
using UnityEngine;
using UnityEngine.UI;

public class UINewGame : MonoBehaviour
{
    [SerializeField] private Image shipModel;
    [SerializeField] private SpriteRenderer shipIcon;

    private void Start()
    {
        this.shipModel.sprite = this.shipIcon.sprite = MainManager.Instance.ShipModel;
    }

    public void ChangeChoiceLeft()
    {
        this.shipModel.sprite = this.shipIcon.sprite = MainManager.Instance.ChangeToPreviousShipModel();
    }

    public void ChangeChoiceRight()
    {
        this.shipModel.sprite = this.shipIcon.sprite = MainManager.Instance.ChangeToNextShipModel();
    }
}
