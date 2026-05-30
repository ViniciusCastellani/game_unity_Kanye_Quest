using UnityEngine;

public class pausar_jogo : MonoBehaviour
{
    public GameObject telaDePause;
    public GameObject pontos_txt;     

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Se a tela de pause já estiver ativa, o botão Escape despausa o jogo
            if (telaDePause.activeSelf)
            {
                ContinuarJogo();
            }
            else
            {
                PausarJogo();
            }
        }
    }

    public void PausarJogo()
    {
        // ativa a tela de pause
        telaDePause.SetActive(true);

        // Oculta os textos de pontos e FPS da tela
        if (pontos_txt != null) 
            pontos_txt.SetActive(false);

        // paralisa o tempo
        Time.timeScale = 0f;
    }

    public void ContinuarJogo()
    {
        // desativa a tela de pause
        telaDePause.SetActive(false);

        // Volta a mostrar os textos de pontos 
        if (pontos_txt != null) 
            pontos_txt.SetActive(true);

        // volta o tempo para a velocidade normal
        Time.timeScale = 1f;
    }
}