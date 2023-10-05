using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip_NJ : InputListenerBase
{
    public float moveSpeed = 5f;
    public float projectileSpeed = 10f;
    public int maxProjectiles = 20;
    public float projectileLifetime = 3f;

    private Rigidbody2D _rb;
    //private GameObject _projectilePrefab;
    public GameObject projectilePrefab;
    private List<GameObject> projectiles = new List<GameObject>();
    private Vector2 _mousePositionAtFrame;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D not found on the GameObject.");
        }
        InitializeProjectilePool();
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
            GameObject newProjectile = Instantiate(projectilePrefab, Vector3.zero, Quaternion.identity);
            newProjectile.SetActive(false);
            projectiles.Add(newProjectile);
        }
    }

    private void CheckProjectileOutOfBounds()
    {
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        foreach (GameObject projectile in projectiles)
        {
            if (projectile.transform.position.x < -screenBounds.x ||
            projectile.transform.position.x > screenBounds.x ||
            projectile.transform.position.y < -screenBounds.y ||
            projectile.transform.position.y > screenBounds.y)
            {
                projectile.SetActive(false);
            }
        }
    }
    private void CheckProjectileLifetime()
    {
        foreach (GameObject projectile in projectiles)
        {
            // Decrease the remaining lifetime of the projectile
            //projectile.remainingLifetime -= Time.deltaTime;

            // Check if the projectile's lifetime has expired
            //if (projectile.remainingLifetime <= 0f)
            {
                projectile.SetActive(false);
            }
        }
    }

    public override void ProcessMouseButtonDown(int _button)
    {
        if (_button == 0) // tire simple
        {
            GameObject newProjectile = GetInactiveProjectile();

            if (newProjectile != null)
            {
                newProjectile.transform.position = transform.position;

                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(_mousePositionAtFrame.x, _mousePositionAtFrame.y, Camera.main.nearClipPlane));
                Vector2 fireDirection = (mouseWorldPosition - transform.position).normalized;

                Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

                rb.velocity = fireDirection * projectileSpeed;

                newProjectile.SetActive(true);
            }
        }
        else { 
            //tire laser
        }
    }
    private GameObject GetInactiveProjectile()
    {
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
        Debug.Log("ProcessMouseButtonUp");
    }
    public override void ProcessMousePosition(Vector2 _mousePosition)
    {
        _mousePositionAtFrame = _mousePosition;

        Vector3 mouseWorldPosition = new Vector3(Camera.main.ScreenToWorldPoint(_mousePosition).x,
            Camera.main.ScreenToWorldPoint(_mousePosition).y, 0) - transform.position;
        //enlever la position du joueur comparé à 0.0
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mouseWorldPosition);
    }
    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
        _rb.velocity = new Vector2(_inputAxes.x * moveSpeed, _inputAxes.y * moveSpeed);
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
