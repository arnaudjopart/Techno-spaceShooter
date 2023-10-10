using UnityEngine;

namespace Mika
{
    public class ShipController : InputListenerBase
    {
        [Header("Input Settings")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;

        [Header("Projectile Settings")]
        [SerializeField] private GameObject projectilePrefab;

        [Header("Sound Settings")]
        [SerializeField] private AudioClip playerAttackClip;
        private AudioSource audioSource;

        [Header("Ghost Ship Settings")]
        private Vector2 bounds;
        [SerializeField] private GameObject[] ghostShips;
        [SerializeField] private Transform shipParent;
        public int Lives { get; private set; } = 3;

        private void Awake()
        {
            bounds = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
            Time.timeScale = 1f;
            this.audioSource = GetComponent<AudioSource>();
            InitGhostShips();
        }

        private void InitGhostShips()
        {
            ghostShips[0].transform.position = 2f * bounds.y * Vector3.up;
            ghostShips[1].transform.position = -ghostShips[0].transform.position;
            ghostShips[2].transform.position = 2f * bounds.x * Vector3.right;
            ghostShips[3].transform.position = -ghostShips[2].transform.position;
            ghostShips[4].transform.position = ghostShips[0].transform.position + ghostShips[2].transform.position;
            ghostShips[5].transform.position = -ghostShips[4].transform.position;
            ghostShips[6].transform.position = ghostShips[0].transform.position - ghostShips[2].transform.position;
            ghostShips[7].transform.position = -ghostShips[6].transform.position;
        }

        public override void ProcessInputAxes(Vector2 input)
        {
            transform.Rotate(-Vector3.forward, input.x * rotationSpeed * Time.deltaTime);
            // Les vaisseaux fantômes sont orientés comme le vaisseau principal
            foreach (var ghostShip in ghostShips)
            {
                ghostShip.transform.rotation = transform.rotation;
            }
        }

        public override void ProcessKeyCodeDown(KeyCode _keyCode)
        {
            if (_keyCode == KeyCode.Space)
            {
                this.audioSource.PlayOneShot(this.playerAttackClip);
                Vector3 offset = transform.up;
                offset *= 0.5f;
                Vector3 spawnPos = transform.position + offset;
                Quaternion wantedRotation = transform.rotation;
                GameObject o = Instantiate(projectilePrefab, spawnPos, wantedRotation);
                o.transform.SetParent(transform);
                Destroy(o, 2f);
            }
        }

        private void LateUpdate()
        {
            // déplace le plateau de vaisseaux
            shipParent.transform.Translate(moveSpeed * Time.deltaTime * transform.up);
            // téléporte le plateau de vaisseaux s'il est hors des limites ou non
            shipParent.transform.position = new Vector3((IsOutsideXBounds() ? -1 : 1) * transform.position.x, (IsOutsideYBounds() ? -1 : 1) * transform.position.y, transform.position.z);
        }

        private bool IsOutsideXBounds()
        {
            return transform.position.x < -bounds.x || transform.position.x > bounds.x;
        }

        private bool IsOutsideYBounds()
        {
            return transform.position.y < -bounds.y || transform.position.y > bounds.y;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.SetActive(false);
            LoseLife(1);
            if (Lives <= 0)
            {
                EventManager.InvokeGameOverEvent();
            }
        }

        private void LoseLife(int lostLives)
        {
            EventManager.InvokePlayerLifeChangedEvent(Lives, Lives -= lostLives);
        }
    }
}