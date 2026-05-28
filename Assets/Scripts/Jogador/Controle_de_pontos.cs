using TMPro;
using UnityEngine;

public class ControleDePontos : MonoBehaviour
{
    public int pontos;
    public int qtd_total_pontos;
    public TextMeshProUGUI pontosTexto;
    private AudioSource fonteDeAudio;
    public AudioClip somDosColetaveis;
    void Start()
    {
        pontos = 0;
        fonteDeAudio = GetComponent<AudioSource>();
        pontosTexto.text = "Pontos: 0/" + qtd_total_pontos;
    }
    private void OnTriggerEnter2D(Collider2D objetoColidido)
    {
        if (objetoColidido.CompareTag("coletavel"))
        {
            objetoColidido.gameObject.SetActive(false);
            ContarPontos();
        }
    }
    void ContarPontos()
    {
        pontos++;
        pontosTexto.text = "Pontos: " + pontos + "/" + qtd_total_pontos;
        fonteDeAudio.PlayOneShot(somDosColetaveis);
    }

    public bool TemTodosOsPontos()
    {
        return pontos >= qtd_total_pontos;
    }
}