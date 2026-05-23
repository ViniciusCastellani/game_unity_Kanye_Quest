using TMPro;
using UnityEngine;

public class ControleDePontos : MonoBehaviour
{
    public int pontos;
    public TextMeshProUGUI pontosTexto;
    private AudioSource fonteDeAudio;
    public AudioClip somDosColetaveis;
    void Start()
    {
        pontos = 0;
        fonteDeAudio = GetComponent<AudioSource>();
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
        pontosTexto.text = "Pontos: " + pontos;
        fonteDeAudio.PlayOneShot(somDosColetaveis);
    }
}