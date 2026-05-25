using UnityEngine;
using UnityEngine.SceneManagement;

public class passar_de_fase : MonoBehaviour
{
    public GameObject telaStageClear;
    public string nomeDaProximaFase;
    private AudioSource fonteDeAudio;
    public AudioClip somDoStageClear;

    public GameObject pontos_txt;
    public GameObject contador_fps_txt;

    private Animator animatorJogador;
    public movimento_jogador movimentoJogador;

    // Contador de tempo
    private float temporizador = 0f;
    private bool contando = false;

    void Start()
    {
        fonteDeAudio = GetComponent<AudioSource>();
        animatorJogador = GetComponentInChildren<Animator>();

        if (movimentoJogador == null)
            movimentoJogador = GetComponent<movimento_jogador>();
    }

    void Update()
    {
        if (!contando) return;

        temporizador += Time.unscaledDeltaTime; // ignora o timeScale

        if (temporizador >= 3f)
        {
            contando = false;
            telaStageClear.SetActive(true);
            Time.timeScale = 0.01f;
        }
    }

    public void chamarTelaDeFimDeFase()
    {
        if (movimentoJogador != null)
            movimentoJogador.enabled = false;

        // Zera a velocidade do Rigidbody2D para parar o jogador
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 0f; // evita cair durante a animação
        }

        if (pontos_txt != null) pontos_txt.SetActive(false);
        if (contador_fps_txt != null) contador_fps_txt.SetActive(false);

        fonteDeAudio.Stop();
        fonteDeAudio.PlayOneShot(somDoStageClear);

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

    private void OnTriggerEnter2D(Collider2D objetoColidido)
    {
        if (objetoColidido.CompareTag("fimDeFase"))
        {
            chamarTelaDeFimDeFase();
        }
    }
}