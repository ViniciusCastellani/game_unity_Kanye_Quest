using UnityEngine;
using UnityEngine.SceneManagement;

public class game_over : MonoBehaviour
{
    public GameObject telaGameOver;
    public string cenaMenuInicial;
    private AudioSource fonteDeAudio;
    public AudioClip somDoGameOver;
    void Start()
    {
        fonteDeAudio = GetComponent<AudioSource>();
    }
    public void FimDeJogo()
    {
        // liga a tela de Game Over
        telaGameOver.SetActive(true);
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
