using UnityEngine;

public class ShipController : InputListenerBase
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private GameObject projectilePrefab;

    public override void ProcessInputAxes(Vector2 input)
    {
        this.transform.Rotate(-Vector3.forward, input.x * this.rotationSpeed * Time.deltaTime);
    }

    public override void ProcessKeyCodeDown(KeyCode _keyCode)
    {
        if (_keyCode == KeyCode.Space)
        {
            Vector3 spawnPos = this.transform.position + this.transform.forward;
            Quaternion wantedRotation = this.transform.rotation;
            GameObject o = Instantiate(this.projectilePrefab, spawnPos, wantedRotation);
            o.transform.SetParent(this.transform);
            Destroy(o, 2f);
        }
    }

    private void Update()
    {
        this.transform.Translate(this.moveSpeed * Time.deltaTime * Vector3.up);
    }
}
