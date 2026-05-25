using UnityEngine;

public class ataque_jogador : MonoBehaviour
{
    public float impulsoParaCima = 0.5f;
    private AudioSource fonteDeAudio;
    public AudioClip somDoAtaque;
    private Rigidbody2D jogadorRB;
    void Start()
    {
        jogadorRB = GetComponent<Rigidbody2D>();
        fonteDeAudio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D objetoColidido)
    {
        if (objetoColidido.CompareTag("inimigo"))
        {
            GameObject inimigo = objetoColidido.gameObject;
            AtaqueDePulo(inimigo);
        }
    }
    void AtaqueDePulo(GameObject inimigo)
    {
        Destroy(inimigo);
        fonteDeAudio.PlayOneShot(somDoAtaque);
        // Pequeno impulso para o jogador quicar
        jogadorRB.linearVelocity = new
        Vector2(jogadorRB.linearVelocity.x, impulsoParaCima);
    }
}
