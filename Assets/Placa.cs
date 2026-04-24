using UnityEngine;

public class Placa : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject pressKeyUI;

    public void MostrarHint(bool estado)
    {
        pressKeyUI.SetActive(estado);
    }

    public void Interagir()
    {
        dialogBox.SetActive(!dialogBox.activeSelf);
    }
}