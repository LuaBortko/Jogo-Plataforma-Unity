using UnityEngine;

public class Letras : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 2f;
    public float amplitude = 0.1f;   // altura do movimento
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 startPos;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position =
            new Vector3(startPos.x,
                        startPos.y + yOffset,
                        startPos.z);
    }
}
