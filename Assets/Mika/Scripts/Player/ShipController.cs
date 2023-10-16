using UnityEngine;

namespace Mika
{
    public class ShipController : InputListenerBase
    {
        [Header("Input Settings")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;

        [Header("Weapon Settings")]
        [SerializeField] private WeaponData[] weaponData;
        private int currentWeaponId;
        private WeaponData currentWeapon;

        [Header("Sound Settings")]
        [SerializeField] private AudioClip playerAttackClip;
        private AudioSource audioSource;

        [Header("Life Settings")]
        [SerializeField] private int maxLives = 3;
        public int Lives { get; private set; }
        private SpriteRenderer spriteRenderer;
        private CapsuleCollider2D shipCollider;

        private void Awake()
        {
            this.audioSource = GetComponent<AudioSource>();
            this.spriteRenderer = GetComponent<SpriteRenderer>();
            this.shipCollider = GetComponent<CapsuleCollider2D>();
            SetShipModel();
        }

        private void Start()
        {
            ResetLife();
            ChangeWeapon(0);
        }

        private void SetShipModel()
        {
            this.spriteRenderer.sprite = MainManager.Instance.ShipModel;
            bool isUfo = MainManager.Instance.IsUfo;
            this.shipCollider.offset = isUfo ? Vector2.zero : new Vector2(0f, -0.1f);
            this.shipCollider.size = isUfo ? Vector2.one * 1.12f : new Vector2(1.12f, 0.6f);
        }

        public override void ProcessMousePosition(Vector2 _mousePosition)
        {
            if (GameManager.Instance?.GameState != GameStates.STARTED)
            {
                return;
            }
            // déplace et oriente le joueur d'après la position de la souris
            Vector3 worldPos = Camera.main.ScreenToWorldPoint((Vector3)_mousePosition);
            worldPos.z = 0f;
            Vector3 targetDir = (worldPos - this.transform.position).normalized;
            Debug.DrawLine(this.transform.position, targetDir * 5f, Color.white);
            Vector3 velocity = this.moveSpeed * Vector3.up;
            this.transform.Translate(velocity * Time.deltaTime);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(Vector3.forward, targetDir), rotationSpeed * Time.deltaTime);  
        }

        public override void ProcessMouseButtonDown(int _button)
        {
            if (GameManager.Instance?.GameState != GameStates.STARTED)
            {
                return;
            }
            if (_button == 0)
            {
                FireSelectedWeapon();
            }
            else if (_button == 1)
            {
                ChangeWeapon();
            }
        }

        private void FireSelectedWeapon()
        {
            if (!this.audioSource.isPlaying)
            {
                this.audioSource.PlayOneShot(this.playerAttackClip);
            }
            Vector3 offset = transform.up;
            offset *= 0.5f;
            Vector3 spawnPos = transform.position + offset;
            Quaternion wantedRotation = transform.rotation;
            GameObject o = WeaponPool.Instance.Get(this.currentWeapon);
            o.transform.SetPositionAndRotation(spawnPos, wantedRotation);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (GameManager.Instance?.GameState != GameStates.STARTED)
            {
                return;
            }
            if (collision.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.Die(false);
            }
            LoseLife(1);
            if (Lives <= 0)
            {
                GameManager.Instance?.GameOver();
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

        private void ChangeWeapon(int weaponId)
        {
            this.currentWeaponId = weaponId;
            this.currentWeapon = this.weaponData[this.currentWeaponId];
            EventManager.InvokePlayerChangeWeaponEvent(this.currentWeapon);
        }

        private void ChangeWeapon()
        {
            ChangeWeapon((this.currentWeaponId + 1) % this.weaponData.Length);
        }
    }
}