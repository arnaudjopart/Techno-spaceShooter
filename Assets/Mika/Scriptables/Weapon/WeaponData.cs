using UnityEngine;

namespace Mika
{
    [CreateAssetMenu(fileName = "weapon", menuName = "New Weapon", order = 52)]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        public GameObject prefab;
        public int amount;
        public Sprite icon;
        public Color iconColor;
    }
}