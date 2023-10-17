using UnityEngine;

namespace Mika
{
    public class SimpleMoveForward : MonoBehaviour
    {
        protected Vector3 velocity = Vector3.zero;
        protected IMovable movable;

        protected virtual void Awake()
        {
            this.movable = GetComponent<IMovable>();
        }

        protected virtual void Update()
        {
            if (this.movable.Speed > 0f )
            {
                this.transform.Translate(this.velocity * Time.deltaTime);
            }
        }

        public void SetPositionAndVelocity(Vector3 pos, Vector3 velocity)
        {
            this.transform.position = pos;
            this.velocity = velocity * this.movable.Speed; // scaleFactor
        }
    }
}