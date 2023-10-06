using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip_NJ : InputListenerBase
{
    public float moveSpeed = 5f,
        projectileSpeed = 10f,
        projectileLifetime = 3f,
        worldBorder = 5f;
    public int maxProjectiles = 20;
    public GameObject projectilePrefab;

    private Rigidbody2D rb;
    private Vector3 screenBounds;
    private List<GameObject> projectiles = new List<GameObject>();
    //public Projectile projectilePrefab;
    //private List<Projectile> projectiles = new List<Projectile>();
    private Vector2 _mousePositionAtFrame;
    private bool tireLazerActif = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        InitializeProjectilePool();
    }
    private void Start()
    {
        //if change size of window/screen in game ?
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        //screenBoundsXMax = screenBounds.x; screenBoundsYMax = screenBounds.y;
        //Debug.Log("screenBounds: " + screenBounds); //screenBounds: (8.89, 5.00, -10.00) on 4k in Unity
    }
    private void HandleProjectileCollision(Collider2D other)
    {
        Debug.Log("Collision avec : " + other.gameObject.name);
    }
    private void Update()
    {
        //CheckProjectileLifetime();
        CheckProjectileOutOfBounds();
    }
    private void InitializeProjectilePool()
    {
        for (int i = 0; i < maxProjectiles; i++)
        {
            //Projectile newProjectile = Instantiate(projectilePrefab, Vector3.zero, Quaternion.identity);
            GameObject newProjectile = Instantiate(projectilePrefab, Vector3.zero, Quaternion.identity);
            newProjectile.SetActive(false);
            //newProjectile.OnCollision += HandleProjectileCollision;
            projectiles.Add(newProjectile);
        }
    }

    private void CheckProjectileOutOfBounds()
    {
        //foreach (Projectile projectile in projectiles)
        foreach (GameObject projectile in projectiles)
            {
            if (projectile.transform.position.x < -screenBounds.x ||
                projectile.transform.position.x > screenBounds.x ||
                projectile.transform.position.y < -screenBounds.y ||
                projectile.transform.position.y > screenBounds.y)
            {
                //projectile.DesActive();
                projectile.SetActive(false);
            }
        }
    }
    private void CheckProjectileLifetime()
    {
        //foreach (Projectile projectile in projectiles)
        foreach (GameObject projectile in projectiles)
        {
            // Decrease the remaining lifetime of the projectile
            //projectile.remainingLifetime -= Time.deltaTime;

            // Check if the projectile's lifetime has expired
            //if (projectile.remainingLifetime <= 0f)
            {
                //projectile.DesActive();
                projectile.SetActive(false);
            }
        }
    }

    public override void ProcessMouseButtonDown(int _button)
    {
        if (_button == 0) // tire simple
        {
            //Projectile newProjectile = GetInactiveProjectile();
            GameObject newProjectile = GetInactiveProjectile();

            if (newProjectile != null)
            {
                newProjectile.transform.position = transform.position; // + transform.forward;
                newProjectile.transform.rotation = transform.rotation;
                newProjectile.SetActive(true);

                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(_mousePositionAtFrame.x, _mousePositionAtFrame.y, Camera.main.nearClipPlane));
                Vector2 fireDirection = (mouseWorldPosition - newProjectile.transform.position).normalized;

                Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
                rb.velocity = fireDirection * projectileSpeed;
            }
        }
        else {
            //tire laser en laissant appuyer ? -> ProcessMouseButtonUp + bool
            tireLazerActif = true;
            GameObject newProjectile = GetInactiveProjectile();
            if (newProjectile != null)
            {
                newProjectile.transform.position = transform.position;
                newProjectile.transform.rotation = transform.rotation;
                newProjectile.SetActive(true);

                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(_mousePositionAtFrame.x, _mousePositionAtFrame.y, 0));
                Vector2 fireDirection = (mouseWorldPosition - transform.position).normalized;

                Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
                rb.velocity = fireDirection * projectileSpeed;
            }

        }
    }
    //private Projectile GetInactiveProjectile()
    private GameObject GetInactiveProjectile()
    {
        //foreach (Projectile projectile in projectiles)
        foreach (GameObject projectile in projectiles)
        {
            if (!projectile.activeInHierarchy)
            {
                return projectile;
            }
        }
        return null;
    }

    public override void ProcessMouseButtonUp(int _button)
    {
        //Debug.Log("ProcessMouseButtonUp");
    }
    public override void ProcessMousePosition(Vector2 _mousePosition)
    {
        _mousePositionAtFrame = _mousePosition;

        Vector3 mouseWorldPosition = new Vector3(Camera.main.ScreenToWorldPoint(_mousePosition).x,
            Camera.main.ScreenToWorldPoint(_mousePosition).y, 0) - transform.position; //enlever la position actuelle du joueur comparé à 0.0
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mouseWorldPosition);
    }
    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
//Debug.Log("Ship Position: " + transform.position + " - screenBounds:" + screenBounds);
        if (Math.Abs(transform.position.x) >= 0 && Math.Abs(transform.position.x) <= screenBounds.x && Math.Abs(transform.position.y) >= 0 && Math.Abs(transform.position.y) <= screenBounds.y)
            rb.velocity = new Vector2(_inputAxes.x * moveSpeed, _inputAxes.y * moveSpeed);
        else {
            Vector3 newPosition = transform.position;

            if (transform.position.x < -screenBounds.x || transform.position.x > screenBounds.x)
            {
                // Inverser la direction en X
                newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x, screenBounds.x);
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y) * 8;
            }

            if (transform.position.y < -screenBounds.y || transform.position.y > screenBounds.y)
            {
                // Inverser la direction en Y
                newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y, screenBounds.y);
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y) * 8;
            }
            transform.position = newPosition;

        }
    }

    public override void ProcessKeyCodeDown(KeyCode _keyCode)
    {
        Debug.Log("space down");
    }

    public override void ProcessKeyCodeUp(KeyCode _keyCode)
    {
        Debug.Log("space up");
    }

}
