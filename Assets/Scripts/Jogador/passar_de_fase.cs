using UnityEngine;
using UnityEngine.SceneManagement;

public class passar_de_fase : MonoBehaviour
{
    public GameObject telaStageClear;
    public string nomeDaProximaFase;
    private AudioSource fonteDeAudio;
    public AudioClip somDoStageClear;

    public GameObject pontosTxt;
    public GameObject contadorFpsTxt;
    public GameObject mensagemFaltandoPontosTxt;

    private Animator animatorJogador;
    public movimento_jogador movimentoJogador;

    public ControleDePontos controleDePontos;
    public movimento_pulo_jogador movimentoPuloJogador;

    private float temporizador = 0f;
    private bool contando = false;

    private float temporizadorMensagem = 0f;
    private bool contandoMensagem = false;

    private bool aguardandoPousoParaGanhar = false;

    void Start()
    {
        fonteDeAudio = GetComponent<AudioSource>();
        animatorJogador = GetComponentInChildren<Animator>();

        if (movimentoJogador == null)
            movimentoJogador = GetComponent<movimento_jogador>();

        if (controleDePontos == null)
            controleDePontos = GetComponent<ControleDePontos>();

        if (movimentoPuloJogador == null)
            movimentoPuloJogador = GetComponent<movimento_pulo_jogador>();
    }

    void Update()
    {
        if (aguardandoPousoParaGanhar)
        {
            if (movimentoPuloJogador != null && movimentoPuloJogador.GetEstaNoChao())
            {
                aguardandoPousoParaGanhar = false; 
                chamarTelaDeFimDeFase();
            }
            return; 
        }

        if (contandoMensagem)
        {
            temporizadorMensagem += Time.unscaledDeltaTime;

            if (temporizadorMensagem >= 9f)
            {
                if (mensagemFaltandoPontosTxt != null)
                    mensagemFaltandoPontosTxt.SetActive(false);

                contandoMensagem = false;
            }
        }

        if (!contando) return;

        temporizador += Time.unscaledDeltaTime;

        if (temporizador >= 9f)
        {
            contando = false;
            telaStageClear.SetActive(true);
            Time.timeScale = 0.01f;
        }
    }

    public void verificarFimDeFase()
    {
        if (controleDePontos != null && controleDePontos.TemTodosOsPontos())
        {
            if (movimentoPuloJogador != null && movimentoPuloJogador.GetEstaNoChao())
            {
                chamarTelaDeFimDeFase();
            }
            else
            {
                aguardandoPousoParaGanhar = true;
            }
        }
        else
        {
            mensagemFaltandoPontosTxt.SetActive(true);
            contandoMensagem = true;
        }
    }

    private void chamarTelaDeFimDeFase()
    {
 
        if (movimentoJogador != null) 
            movimentoJogador.enabled = false;
        
        if (movimentoPuloJogador != null) 
            movimentoPuloJogador.enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 0f;
        }

        if (pontosTxt != null) pontosTxt.SetActive(false);
        if (contadorFpsTxt != null) contadorFpsTxt.SetActive(false);

        if (fonteDeAudio != null)
        {
            fonteDeAudio.Stop();
            fonteDeAudio.PlayOneShot(somDoStageClear);
        }

        if (animatorJogador != null)
            animatorJogador.SetTrigger("vitoria");

        temporizador = 0f;
        contando = true;
    }

    public void carregarProximaFase()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nomeDaProximaFase);
    }

    public void EsconderMensagemImediatamente()
    {
        contandoMensagem = false;
        temporizadorMensagem = 0f;
        if (mensagemFaltandoPontosTxt != null)
            mensagemFaltandoPontosTxt.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D objetoColidido)
    {
        if (objetoColidido.CompareTag("fimDeFase"))
        {
            verificarFimDeFase();
        }
    }
}