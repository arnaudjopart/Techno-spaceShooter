using UnityEngine;

internal class WeaponSystemTerence : WeaponSystemBase
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject roquette;
    [SerializeField] Vector3 projectileOffset;
    public override void ProcessShootPrimaryWeapon()
    {
        Instantiate(projectile, transform.TransformPoint(projectileOffset) , transform.rotation);
    }

    public override void ProcessShootSecondaryWeapon()
    {
        Instantiate(roquette, transform.position, transform.rotation);
    }
}