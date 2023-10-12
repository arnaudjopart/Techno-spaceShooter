using UnityEngine;

namespace Mika
{
    public class AsteroidMove : MonoBehaviour
    {
        private Vector3 velocity = Vector3.zero;
        private IMovable movable;

        private void Awake()
        {
            movable = GetComponent<IMovable>();
        }

        private void Update()
        {
            transform.Translate(velocity * Time.deltaTime);
        }

        public void SetPositionAndVelocity(Vector3 pos, Vector3 velocity)
        {
            transform.position = pos;
            this.velocity = velocity * movable.Speed; // scaleFactor
        }
    }
}