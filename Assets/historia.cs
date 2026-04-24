using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Historia : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    public TextMeshProUGUI hintUI; // "Aperte espaço"

    [TextArea]
    public string historia;

    public float velocidade = 0.05f;

    private bool terminou = false;
    private bool pulando = false;

    void Start()
    {
        hintUI.gameObject.SetActive(false);
        StartCoroutine(MostrarTexto());
    }

    IEnumerator MostrarTexto()
    {
        textoUI.text = "";
        terminou = false;
        pulando = false;

        foreach (char letra in historia)
        {
            if (pulando)
            {
                textoUI.text = historia;
                break;
            }

            textoUI.text += letra;
            yield return new WaitForSeconds(velocidade);
        }

        terminou = true;
        hintUI.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!terminou)
            {
                // pular animação de texto
                pulando = true;
            }
            else
            {
                // ir para a fase
                SceneManager.LoadScene("Fase1");
            }
        }
    }
}