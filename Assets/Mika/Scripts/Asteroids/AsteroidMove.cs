using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private IMovable movable;

    private void Awake()
    {
        this.movable = GetComponent<IMovable>();
    }

    private void Update()
    {
        this.transform.Translate(this.velocity * Time.deltaTime);
    }

    public void SetPositionAndVelocity(Vector3 pos, Vector3 velocity)
    {
        this.transform.position = pos;
        this.velocity = velocity * this.movable.Speed; // scaleFactor
    }
}
