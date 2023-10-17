using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GhostWrappingSystem : BorderTeleportation
{
    protected Transform ghostSystem;
    [SerializeField] protected GameObject ghostSystemPrefab;

    protected override void Awake()
    {
        base.Awake();
        m_bounds = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        InitGhosts();
    }

    private void InitGhosts()
    {
        // l'image actuelle
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        // crée un gameObject servant de conteneur
        GameObject ghostWrappingSystem = GameObject.Find("GhostWrappingSystems");
        if (ghostWrappingSystem == null)
        {
            ghostWrappingSystem = new GameObject("GhostWrappingSystems");
        }
        this.ghostSystem = Instantiate(this.ghostSystemPrefab, ghostWrappingSystem.transform.position, Quaternion.identity, ghostWrappingSystem.transform).transform;
        Vector3 pos1 = 2f * m_bounds.y * Vector3.up;
        Vector3 pos2 = 2f * m_bounds.x * Vector3.right;
        Vector3 pos3 = pos1 + pos2;
        Vector3 pos4 = pos1 - pos2;
        Vector3[] positions = { pos1, pos2, -pos1, -pos2, pos3, pos4, -pos3, -pos4 };
        // ajoute 8 images au conteneur
        for (int i = 0; i < positions.Length; i++)
        {
            Transform o = this.ghostSystem.GetChild(i);
            o.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            o.transform.position = positions[i];
        }
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
        // le ghost system suit la position du joueur
        this.ghostSystem.transform.position = this.transform.position;
        // Les vaisseaux fantômes sont orientés comme le vaisseau principal
        foreach (Transform ghost in this.ghostSystem)
        {
            ghost.rotation = this.transform.rotation;
        }
    }
}
