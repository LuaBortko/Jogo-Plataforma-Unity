using UnityEngine;
using UnityEngine.SceneManagement;
public class Vitoria : MonoBehaviour
{
    void OnGUI()
    {
        GUIStyle titleStyle = new GUIStyle();
        titleStyle.fontSize = 100;
        titleStyle.alignment = TextAnchor.MiddleCenter;
        titleStyle.normal.textColor = Color.black;

        GUIStyle textStyle = new GUIStyle();
        textStyle.fontSize = 50;
        textStyle.alignment = TextAnchor.MiddleCenter;
        textStyle.normal.textColor = Color.black;

        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontSize = 30;

        float centerX = Screen.width / 2;
        float centerY = Screen.height / 2;

        // Texto principal
        string texto = "Parabuens";

        GUI.Label(new Rect(centerX - 200, centerY - 100, 400, 60), texto, titleStyle);

        // Texto secundário
        GUI.Label(new Rect(centerX - 200, centerY + 100, 400, 40), "Pontuação: "+ Gui.pontuacao, textStyle);

        // Botão
        if (GUI.Button(new Rect(centerX - 150, centerY + 300, 300, 80),"Menu", buttonStyle))
        {
            Gui.vida = 3;
            Gui.pontuacao = 0;
            SceneManager.LoadScene("Menu");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}