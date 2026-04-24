using UnityEngine;
using UnityEngine.SceneManagement;
public class Gui : MonoBehaviour
{
    public static int pontuacao = 0;
    public static int vida = 3;

    public static int moedasTotais = 0;

    public GameObject Passaro;
    private static float timer;
    private static float delay;
    public static bool cont = false;
    

    void Start()
    {
        vida = 3;
        pontuacao = 0;
        moedasTotais = FindObjectsByType<moeda>(FindObjectsSortMode.None).Length;
        timer = 0f;
        ConfigurarFase();
    }

    public static void ConfigurarFase()
    {
        string nomeFase = SceneManager.GetActiveScene().name;
        timer = 0; 
        moedasTotais = FindObjectsByType<moeda>(FindObjectsSortMode.None).Length;
        if (nomeFase == "Fase1")
        {
            cont = true;
            delay = 5f; // poucos pássaros
        }
        else if (nomeFase == "Fase2")
        {
            cont = true;
            delay = 2f;
        }
        else
        {
            cont = false;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += AoCarregarCena;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= AoCarregarCena;
    }
    void AoCarregarCena(Scene scene, LoadSceneMode mode)
    {
        ConfigurarFase();
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.white;

        GUI.Label(new Rect(Screen.width - 250, 20, 300, 100),
            "Vida: " + vida, style);

        GUI.Label(new Rect(50, 20, 300, 100),
            "Moedas: " + pontuacao, style);
    }

    public static bool TodasMoedasColetadas()
    {
        return pontuacao >= moedasTotais;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= delay && cont)
        {
            float y = Random.Range(-2f, 4f);
            Instantiate(Passaro, new Vector3(9f, y, 0f), Quaternion.identity);
            timer = 0f;
        }
    }
}