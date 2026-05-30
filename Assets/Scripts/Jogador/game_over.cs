using UnityEngine;
using UnityEngine.SceneManagement;

public class game_over : MonoBehaviour
{
    public GameObject telaGameOver;
    public string cenaMenuInicial;
    private AudioSource fonteDeAudio;
    public AudioClip somDoGameOver;

    public GameObject pontos_txt;
    public GameObject mensagem_aviso_pontos;
    public GameObject mensagem_todos_pontos_coletados;

    public passar_de_fase scriptPassarFase;

    void Start()
    {
        fonteDeAudio = GetComponent<AudioSource>();

        if (scriptPassarFase == null)
            scriptPassarFase = FindObjectOfType<passar_de_fase>();
    }

    public void FimDeJogo()
    {
        if (scriptPassarFase != null)
            scriptPassarFase.EsconderMensagemImediatamente();

        // liga a tela de Game Over
        telaGameOver.SetActive(true);
       
        if (pontos_txt != null) 
            pontos_txt.SetActive(false);

        if (mensagem_aviso_pontos != null)
            mensagem_aviso_pontos.SetActive(false);

        if (mensagem_todos_pontos_coletados != null)
            mensagem_todos_pontos_coletados.SetActive(false);

        // Congela o tempo
        Time.timeScale = 0f;
        // Para a musica de fundo
        fonteDeAudio.Stop();
        // Toca o som do Game Over
        fonteDeAudio.PlayOneShot(somDoGameOver);
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f; // Restaura o tempo
                             // Recarrega a cena atual reiniciando o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Desistir()
    {
        Time.timeScale = 1f; // Restaura o tempo
                             // Carrega a cena do Menu Inicial
        SceneManager.LoadScene(cenaMenuInicial);
    }

    private void OnCollisionEnter2D(Collision2D objetoColidido)
    {
        if (objetoColidido.gameObject.CompareTag("inimigo"))
        {
            FimDeJogo();
        }
    }

    private void OnTriggerEnter2D(Collider2D objetoColidido)
    {
        if (objetoColidido.CompareTag("zonaDeMorte"))
        {
            FimDeJogo();
        }
    }
}