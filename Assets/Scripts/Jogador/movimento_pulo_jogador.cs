using UnityEngine;

public class movimento_pulo_jogador : MonoBehaviour
{
    public float alturaDoPulo;
    private Rigidbody2D jogadorRB;
    // chao check
    public Transform detectorDeChao;
    public LayerMask camadaChao;
    public bool estaNoChao;
    public float tamanhoDetectorDeChao;

    //Audios
    private AudioSource fonteDeAudio;
    public AudioClip somDoPulo;
    void Start()
    {
        jogadorRB = GetComponent<Rigidbody2D>();
        fonteDeAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        DetectarChao();
        Pular();
    }
    void DetectarChao()
    {
        estaNoChao = Physics2D.OverlapCircle(detectorDeChao.position,
        tamanhoDetectorDeChao, camadaChao);
    }
    void Pular()
    {
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            jogadorRB.linearVelocity = new Vector2(jogadorRB.linearVelocity.x, alturaDoPulo);
            fonteDeAudio.PlayOneShot(somDoPulo);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectorDeChao.position, tamanhoDetectorDeChao);
    }
}
