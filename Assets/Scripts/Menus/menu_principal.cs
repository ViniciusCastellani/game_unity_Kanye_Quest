using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_principal : MonoBehaviour
{
    public string level01;

    public void IniciarJogo()
    {
        SceneManager.LoadScene(level01);
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}