using UnityEngine;

public class ClickIndicator : MonoBehaviour
{
    public float lifetime = 0.6f;
    public float growSpeed = 2f;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.localScale += Vector3.one * growSpeed * Time.deltaTime;

        Color c = sr.color;
        c.a -= Time.deltaTime * 2f;
        sr.color = c;

        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}