using UnityEngine;

namespace Mika
{
    [DisallowMultipleComponent]
    public sealed class MainManager : MonoBehaviour
    {
        #region Singleton
        public static MainManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            ReadShipModel();
        }
        #endregion

        [SerializeField] private Sprite[] shipModels;
        private const string SHIP_MODEL_KEY = "ShipModel";
        public Sprite ShipModel { get; private set; }
        public int ShipId { get; private set; }
        public bool IsUfo => ShipModel.name.StartsWith("ufo");

        public Sprite ChangeToNextShipModel()
        {
            ShipId = ++ShipId % this.shipModels.Length;
            ShipModel = this.shipModels[ShipId];
            SaveShipModel();
            return ShipModel;
        }

        public Sprite ChangeToPreviousShipModel()
        {
            ShipId--;
            if (ShipId < 0)
            {
                ShipId += this.shipModels.Length;
            }
            ShipModel = this.shipModels[ShipId];
            SaveShipModel();
            return ShipModel;
        }

        private void ReadShipModel()
        {
            ShipId = PlayerPrefs.HasKey(SHIP_MODEL_KEY) ? SearchShipIdByName(PlayerPrefs.GetString(SHIP_MODEL_KEY)) : 0;
            ShipModel = this.shipModels[this.ShipId];
        }

        private void SaveShipModel()
        {
            PlayerPrefs.SetString(SHIP_MODEL_KEY, ShipModel.name);
        }

        private int SearchShipIdByName(string shipName)
        {
            for (int shipId = 0; shipId < this.shipModels.Length; shipId++)
            {
                if (this.shipModels[shipId].name.Equals(shipName))
                {
                    return shipId;
                }
            }
            return 0;
        }
    }
}