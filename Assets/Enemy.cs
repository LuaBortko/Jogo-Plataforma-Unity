using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public static float speed = 2f;

    public float bounceForce = 14f;
    public int dano = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //transform.position = new Vector3(5.2f, 5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = new Vector2(-speed, 0);
        var pos = transform.position; 
        if(pos.x < -8.4){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

        // ponto de contato da colisão
        ContactPoint2D contact = collision.contacts[0];

        // se o player veio de cima
        if (contact.normal.y < -0.5f)
        {
            // impulso para cima
            playerRb.linearVelocity =
                new Vector2(playerRb.linearVelocity.x, bounceForce);

            Morrer();
        }
        else
        {
            // dano lateral
            Player player = collision.gameObject.GetComponent<Player>();
            player.Morre();
        }
    }

    void Morrer()
    {
        Destroy(gameObject);
    }
    
}