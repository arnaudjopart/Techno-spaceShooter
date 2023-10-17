using UnityEngine;

public class Borderbounce : BorderTeleportation
{
    protected override void OnReachBounds(bool isOutsideXBounds, bool isOutsideYBounds)
    {
        // rebondit sur les bords
        this.transform.up = new((isOutsideXBounds ? -1 : 1) * this.transform.up.x, (isOutsideYBounds ? -1 : 1) * this.transform.up.y, this.transform.up.z);
    }
}
