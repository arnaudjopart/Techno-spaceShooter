using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : InputListenerBase
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject roquette;
    [SerializeField] Vector3 projectileOffset;
    [SerializeField] int speed;
    public int nbAsteroidDetruit;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioSource audioShoot;

    private void Awake()
    {
        audioShoot = GetComponent<AudioSource>();

    }
    public override void ProcessMousePosition(Vector2 _mousePosition)
    {
        Vector3 direction = new Vector3(Camera.main.ScreenToWorldPoint(_mousePosition).x,Camera.main.ScreenToWorldPoint(_mousePosition).y, 0)- transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward,direction);
    }

    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
        transform.position += new Vector3(_inputAxes.x, _inputAxes.y, 0)* Time.deltaTime * speed;
    }
    public override void ProcessMouseButtonDown(int _button)
    {
        if (_button == 0) { 
        Instantiate(projectile, transform.TransformPoint(projectileOffset) , transform.rotation);
            audioShoot.PlayOneShot(shootSound);
        }
        if (_button == 1 && nbAsteroidDetruit > 3) 
        {
            Instantiate(shootSound);
            nbAsteroidDetruit -= 3;
            Instantiate(roquette, transform.position, transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gros") || collision.gameObject.CompareTag("Moyen") || collision.gameObject.CompareTag("Petit")) nbAsteroidDetruit++;
    }
}
