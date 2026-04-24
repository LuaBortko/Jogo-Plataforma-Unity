using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;

    public float speed = 6f;
    public float jumpForce = 12f;

    private Rigidbody2D rb2d;
    SpriteRenderer sr;
    public Sprite idleSprite;
    public Sprite rightSprite;
    public Sprite leftSprite;
    private Placa placaAtual;

    private bool isGrounded;

    public float limiteDireita = 8.4f;
    public float limiteEsquerda = -8.4f;
    public string proximaFase;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
        if (placaAtual != null && Input.GetKeyDown(KeyCode.Space))
        {
            placaAtual.Interagir();
        }
        LimitarPosicao();
        VerificarSaida();
    }

    void VerificarSaida()
    {
        if (transform.position.x > limiteDireita)
        {
            if (Gui.TodasMoedasColetadas())
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(proximaFase);
            }
            else
            {
                Vector3 pos = transform.position;
                pos.x = limiteDireita;
                transform.position = pos;

                Debug.Log("Pegue todas as moedas!");
            }
        }
    }

    void Move()
    {
        float move = 0;

        if (Input.GetKey(moveRight)){
            move = 1;
            sr.sprite = rightSprite;
        }
        else if (Input.GetKey(moveLeft)){
            move = -1;
            sr.sprite = leftSprite;
        }else{
            sr.sprite = idleSprite;
        }
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);
    }

    void LimitarPosicao()
    {
        Vector3 pos = transform.position;

        if (pos.x < -8.4f)
            pos.x = -8.4f;

        transform.position = pos;
    }

    public void Morre(){
        transform.position = new Vector3(-8f, 1f, transform.position.z);
        Gui.vida -= 1; 
        if (Gui.vida <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Derrota");
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
        }
    }

    // Detecta chão
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Agua"))
        {
            Morre();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrou no trigger");

        Placa placa = other.GetComponent<Placa>();

        Debug.Log("Placa encontrada? " + placa);

        if (placa != null)
        {
            placaAtual = placa;
            placa.MostrarHint(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Placa placa = other.GetComponentInParent<Placa>();

        if (placa != null && placa == placaAtual)
        {
            placa.MostrarHint(false);
            placaAtual = null;
        }
    }
}