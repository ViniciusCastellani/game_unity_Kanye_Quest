using TMPro;
using UnityEngine;

public class contador_fps : MonoBehaviour
{
    // Variável de texto (arraste no Inspector)
    private TextMeshProUGUI textoFPS;
    void Start()
    {
        textoFPS = GetComponent<TextMeshProUGUI>();
        // Chama a função a cada 1 segundo
        InvokeRepeating(nameof(CalcularFPS), 0f, 1f);
    }
    void CalcularFPS()
    {
        // Calcula o FPS (1 dividido pelo tempo entre frames)
        float fps = 1f / Time.deltaTime;
        // Atualiza o texto com 2 casas decimais
        textoFPS.text = "FPS: " + fps.ToString("00");
        // Define cor baseada no FPS
        if (fps < 10)
        {
            textoFPS.color = Color.red;
        }
        else if (fps < 30)
        {
            textoFPS.color = Color.yellow;
        }
        else
        {
            textoFPS.color = Color.green;
        }
    }
}
