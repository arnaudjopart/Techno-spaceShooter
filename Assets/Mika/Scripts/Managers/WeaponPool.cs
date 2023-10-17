using UnityEngine;

namespace Mika
{
    [DisallowMultipleComponent]
    public class WeaponPool : MonoBehaviour
    {
        #region Singleton
        public static WeaponPool Instance { get; private set; }

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
        }
        #endregion

        [SerializeField] private WeaponData[] weaponPrefabs;

        private void Start()
        {
            foreach(var weapon in this.weaponPrefabs)
            {
                Transform container = new GameObject(weapon.prefab.name).transform;
                container.SetParent(this.transform);
                for (int i = 0; i < weapon.amount; i++)
                {
                    CreateWeapon(weapon, container);
                }
            }
        }

        public GameObject Get(WeaponData weaponData)
        {
            Transform container = GameObject.Find(weaponData.prefab.name).transform;
            for (int i = 0; i < container.childCount; i++)
            {
                GameObject obj = container.GetChild(i).gameObject;
                if (!obj.activeInHierarchy)
                {
                    if (obj.TryGetComponent(out WeaponBase weaponBase)) {
                        weaponBase.ResetLifetime();
                    }
                    obj.SetActive(true);
                    return obj;
                }
            }
            return CreateWeapon(weaponData, container);
        }

        private GameObject CreateWeapon(WeaponData weaponData, Transform container)
        {
            GameObject obj = Instantiate(weaponData.prefab);
            obj.transform.SetParent(this.transform);
            obj.SetActive(false);
            obj.transform.SetParent(container);
            return obj;
        }
    }
}