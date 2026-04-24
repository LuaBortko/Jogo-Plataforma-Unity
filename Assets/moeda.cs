using UnityEngine;

public class moeda : MonoBehaviour
{
    private Animator anim;
    private bool collected = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;

            // ativa animação de coleta
            anim.SetBool("colected", true);
            Gui.pontuacao += 1;
        }
    }

    public void DestroyCoin()
    {
        Destroy(gameObject);
    }
}