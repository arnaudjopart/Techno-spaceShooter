using UnityEngine;

public class BorderTeleportation : MonoBehaviour
{
    protected Vector2 m_bounds;
    protected bool wasInsideBounds = false;

    protected virtual void Awake()
    {
        m_bounds = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    protected virtual void LateUpdate()
    {
        bool isOutsideXBounds = IsOutsideXBounds();
        bool isOutsideYBounds = IsOutsideYBounds();
        // doit avoir été au moins une fois à l'intérieur des limites
        if (this.wasInsideBounds)
        {
            if (isOutsideXBounds || isOutsideYBounds)
            {
                OnReachBounds(isOutsideXBounds, isOutsideYBounds);
            }
        }
        else
        {
            this.wasInsideBounds = !isOutsideXBounds && !isOutsideYBounds;
        }
    }

    protected virtual void OnReachBounds(bool isOutsideXBounds, bool isOutsideYBounds)
    {
        // téléporte le joueur s'il est hors des limites ou non
        this.transform.position = new Vector3((isOutsideXBounds ? -1 : 1) * this.transform.position.x, (isOutsideYBounds ? -1 : 1) * this.transform.position.y, this.transform.position.z);
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
