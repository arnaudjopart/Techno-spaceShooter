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

        [Header("Life Settings")]
        [SerializeField] private int maxLives = 3;
        public int Lives { get; private set; }

        private void Awake()
        {
            this.audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Time.timeScale = 1f;
            ResetLife();
        }

        public override void ProcessInputAxes(Vector2 input)
        {
            transform.Rotate(-Vector3.forward, input.x * rotationSpeed * Time.deltaTime);
        }

        public override void ProcessKeyCodeDown(KeyCode _keyCode)
        {
            if (_keyCode == KeyCode.Space)
            {
                if (!this.audioSource.isPlaying)
                {
                    this.audioSource.PlayOneShot(this.playerAttackClip);
                }
                Vector3 offset = transform.up;
                offset *= 0.5f;
                Vector3 spawnPos = transform.position + offset;
                Quaternion wantedRotation = transform.rotation;
                GameObject o = Instantiate(projectilePrefab, spawnPos, wantedRotation);
                o.transform.SetParent(transform);
                Destroy(o, 2f);
            }
        }

        private void Update()
        {
            // déplace le joueur
            this.transform.Translate(this.moveSpeed * Time.deltaTime * Vector3.up);
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
            SetLife(Lives - lostLives);
        }

        private void SetLife(int newLife)
        {
            EventManager.InvokePlayerLifeChangedEvent(Lives, Lives = newLife, this.maxLives);
        }

        private void ResetLife()
        {
            SetLife(this.maxLives);
        }
    }
}