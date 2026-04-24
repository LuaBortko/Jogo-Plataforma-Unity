using UnityEngine;

public class paralax : MonoBehaviour
{
    public Transform player;
    public float parallaxEffect = 0.5f;

    float length;
    float lastPlayerX;

    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        lastPlayerX = player.position.x;
    }

    void LateUpdate()
    {
    float deltaX = player.position.x - lastPlayerX;

    // movimento parallax
    transform.position += Vector3.right * deltaX * parallaxEffect;

    lastPlayerX = player.position.x;

    // usa a CAMERA como referência
    float camX = Camera.main.transform.position.x;
    float distance = camX - transform.position.x;

    if (distance > length)
        transform.position += Vector3.right * length * 2f;

    else if (distance < -length)
        transform.position += Vector3.left * length * 2f;
    }
}