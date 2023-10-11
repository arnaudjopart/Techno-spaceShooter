using UnityEngine;

public class BorderTeleportation : MonoBehaviour
{
    protected Vector2 m_bounds;

    protected virtual void Awake()
    {
        m_bounds = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    protected virtual void LateUpdate()
    {
        // téléporte le joueur s'il est hors des limites ou non
        this.transform.position = new Vector3((IsOutsideXBounds() ? -1 : 1) * this.transform.position.x, (IsOutsideYBounds() ? -1 : 1) * this.transform.position.y, this.transform.position.z);
    }

    protected virtual bool IsOutsideXBounds()
    {
        return this.transform.position.x < -m_bounds.x || this.transform.position.x > m_bounds.x;
    }

    protected virtual bool IsOutsideYBounds()
    {
        return this.transform.position.y < -m_bounds.y || this.transform.position.y > m_bounds.y;
    }
}
