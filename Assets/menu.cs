using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnGUI()
    {
        GUIStyle titleStyle = new GUIStyle();
        titleStyle.fontSize = 150;
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

        GUI.Label(new Rect(centerX - 200, centerY - 100, 400, 60), "Em Busca da \nCoxinha Perdida", titleStyle);
        // Texto secundário

        // Botão
        if (GUI.Button(new Rect(centerX - 150, centerY + 200, 300, 80),"Começar", buttonStyle))
        {
            SceneManager.LoadScene("Historia");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}