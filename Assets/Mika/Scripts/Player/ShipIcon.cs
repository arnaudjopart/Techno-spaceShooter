using UnityEngine;

namespace Mika
{
    public class ShipIcon : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<SpriteRenderer>().sprite = MainManager.Instance.ShipModel;
        }
    }
}