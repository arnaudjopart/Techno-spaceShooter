using System;
using UnityEngine;

namespace Nicolas.Jourdain
{
    public class Projectile : MonoBehaviour
    {
        public bool activeInHierarchy { get; internal set; }

        // Définissez un délégué pour gérer les événements de collision
        public delegate void CollisionEventHandler(Collider2D other);

        public event CollisionEventHandler OnCollision;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (OnCollision != null)
            {
                OnCollision(other);
            }
        }

        internal void SetActive(bool statut = true)
        {
            //activeInHierarchy = statut;
            SetActive(statut);
        }
        internal void DesActive(bool statut = false)
        {
            //activeInHierarchy = statut;
            SetActive(statut);
        }
    }

}
