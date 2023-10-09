using System;
using TMPro;
using UnityEngine;

public class ShipController : InputListenerBase
{
    [Header("Input Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab;

    [Header("Ghost Ship Settings")]
    private Vector2 bounds;
    [SerializeField] private GameObject[] ghostShips;
    [SerializeField] private Transform shipParent;
    [Header("Game Over Settings")]
    [SerializeField] private GameObject gameOverPanel;
    [Header("Score Settings")]
    [SerializeField] private TMP_Text scoreTxt;
    public int Score { get; private set; } = 0;

    [Header("Lives Settings")]
    [SerializeField] private TMP_Text livesTxt;
    public int Lives { get; private set; } = 3;

    private void Start()
    {
        this.bounds = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        Time.timeScale = 1f;
        InitGhostShips();
    }

    private void InitGhostShips()
    {
        this.ghostShips[0].transform.position = 2f * bounds.y * Vector3.up;
        this.ghostShips[1].transform.position = -this.ghostShips[0].transform.position;
        this.ghostShips[2].transform.position = 2f * bounds.x * Vector3.right;
        this.ghostShips[3].transform.position = -this.ghostShips[2].transform.position;
        this.ghostShips[4].transform.position = ghostShips[0].transform.position + ghostShips[2].transform.position;
        this.ghostShips[5].transform.position = -this.ghostShips[4].transform.position;
        this.ghostShips[6].transform.position = ghostShips[0].transform.position - ghostShips[2].transform.position;
        this.ghostShips[7].transform.position = -this.ghostShips[6].transform.position;
    }

    public override void ProcessInputAxes(Vector2 input)
    {
        this.transform.Rotate(-Vector3.forward, input.x * this.rotationSpeed * Time.deltaTime);
        // Les vaisseaux fantômes sont orientés comme le vaisseau principal
        foreach (var ghostShip in this.ghostShips)
        {
            ghostShip.transform.rotation = this.transform.rotation;
        }
    }

    public override void ProcessKeyCodeDown(KeyCode _keyCode)
    {
        if (_keyCode == KeyCode.Space)
        {
            Vector3 offset = this.transform.up;
            offset *= 0.5f;
            Vector3 spawnPos = this.transform.position + offset;
            Quaternion wantedRotation = this.transform.rotation;
            GameObject o = Instantiate(this.projectilePrefab, spawnPos, wantedRotation);
            o.transform.SetParent(this.transform);
            Destroy(o, 2f);
        }
    }

    private void Update()
    {
        // déplace le plateau de vaisseaux
        this.shipParent.transform.Translate(this.moveSpeed * Time.deltaTime * this.transform.up);
        // téléporte le plateau de vaisseaux s'il est hors des limites ou non
        this.shipParent.transform.position = new Vector3((IsOutsideXBounds() ? -1 : 1) * this.transform.position.x, (IsOutsideYBounds() ? -1 : 1) * this.transform.position.y, this.transform.position.z);
    }

    private bool IsOutsideXBounds()
    {
        return this.transform.position.x < -bounds.x || this.transform.position.x > bounds.x;
    }

    private bool IsOutsideYBounds()
    {
        return this.transform.position.y < -bounds.y || this.transform.position.y > bounds.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Lives -= 1;
        this.livesTxt.text = $"{Lives}";
        if (Lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        this.gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void IncreaseScore(int points)
    {
        Score += points;
        this.scoreTxt.text = $"{Score}";
    }

    public void ResetScore()
    {
        Score = 0;
        this.scoreTxt.text = "0";
    }
}
