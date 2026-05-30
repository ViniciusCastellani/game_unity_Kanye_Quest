using TMPro;
using UnityEngine;

public class ControleDePontos : MonoBehaviour
{
    public int pontos;
    public int qtd_total_pontos;
    public TextMeshProUGUI pontosTexto;
    public GameObject mensagemTodosPontosColetadosTxt;
    private AudioSource fonteDeAudio;
    public AudioClip somDosColetaveis;
    public AudioClip somUltimoColetavel;

    private float temporizadorMensagem = 0f;
    private bool contandoMensagem = false;
    void Start()
    {
        pontos = 0;
        fonteDeAudio = GetComponent<AudioSource>();
        pontosTexto.text = "Pontos: 0/" + qtd_total_pontos;

        if (mensagemTodosPontosColetadosTxt != null)
        {
            mensagemTodosPontosColetadosTxt.SetActive(false);
        }
    }

    void Update()
    {
        if (contandoMensagem)
        {
            temporizadorMensagem += Time.deltaTime;

            if (temporizadorMensagem >= 3f)
            {
                if (mensagemTodosPontosColetadosTxt != null)
                {
                    mensagemTodosPontosColetadosTxt.SetActive(false);
                }

                contandoMensagem = false;
                temporizadorMensagem = 0f; 
            }
        }
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

        if (pontos == qtd_total_pontos)
        {
            fonteDeAudio.PlayOneShot(somUltimoColetavel);

            if (mensagemTodosPontosColetadosTxt != null)
            {
                mensagemTodosPontosColetadosTxt.SetActive(true);
                contandoMensagem = true;
                temporizadorMensagem = 0f;
            }
        }
        else
        {
            fonteDeAudio.PlayOneShot(somDosColetaveis);
        }

    }

    public bool TemTodosOsPontos()
    {
        return pontos >= qtd_total_pontos;
    }
}