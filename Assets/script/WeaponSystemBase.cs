using UnityEngine;

internal abstract class WeaponSystemBase : MonoBehaviour
{
    public abstract void ProcessShootPrimaryWeapon();
    public abstract void ProcessShootSecondaryWeapon();
}