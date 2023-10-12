
using System;
using UnityEngine;

public class PlayerShipPauline : InputListenerBase
{
    [Header("Ship Parameters")] 
    [SerializeField] int speed;
    [SerializeField] float bulletSpeed = 8f;

    [Space(32)]
    [Header("Bullet References")]
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Rigidbody2D bulletPrefab;

    private Rigidbody2D shipRigidbody;


    public void Start()
    {
        shipRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
    }

    public override void ProcessInputAxesRaw(Vector2 _inputAxes)
    {
        if (_inputAxes.magnitude == 0) return;
        var direction = new Vector3(_inputAxes.x, _inputAxes.y, 0).normalized;
        transform.position += direction  * speed * Time.deltaTime;
        transform.up = direction;
    }

    private void HandleShooting()
    {

        Rigidbody2D bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);

        Vector2 shipVelocity = shipRigidbody.velocity;
        Vector2 shipDirection = transform.up;
        float shipForwardSpeed = Vector2.Dot(shipVelocity, shipDirection);

        if (shipForwardSpeed < 0) shipForwardSpeed = 0;

        bullet.velocity = shipVelocity * shipForwardSpeed;

        bullet.AddForce(bulletSpeed * transform.up, ForceMode2D.Impulse);

    }
    public override void ProcessKeyCodeDown(KeyCode _keyCode)
    {
        base.ProcessKeyCodeDown(_keyCode);
        if (_keyCode == KeyCode.Space)
        {
            HandleShooting();
        }
    }

}

  
