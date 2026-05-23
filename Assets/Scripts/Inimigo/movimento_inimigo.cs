using UnityEngine;

public class movimento_inimigo : MonoBehaviour
{
    public float velocidade;
    private Rigidbody2D inimigoRB;
    public Transform detectorDeParede;
    public Transform detectorDeChao;
    public LayerMask camadaChao;
    private float tamanhoDoDetector = 0.5f;
    private bool bateuNaParede = false;
    private bool estaNoChao = true;
    private bool indoParaDireita = true;
    private float direcao = 1;
    void Start()
    {
        inimigoRB = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        DetectarObstaculos();
        Patrulhar();
    }

    void Patrulhar()
    {
        if (indoParaDireita)
            direcao = 1;
        else
            direcao = -1;
        inimigoRB.linearVelocity = new Vector2(direcao * velocidade, inimigoRB.linearVelocity.y);
        // Vira se encontrar parede ou beirada
        if (bateuNaParede || !estaNoChao)
            Virar();
    }
    void DetectarObstaculos()
    {
        bateuNaParede = Physics2D.OverlapCircle(detectorDeParede.position, tamanhoDoDetector, camadaChao);
        estaNoChao = Physics2D.OverlapCircle(detectorDeChao.position, tamanhoDoDetector, camadaChao);
    }
    void Virar()
    {
        // Inverte a direção
        indoParaDireita = !indoParaDireita;
        // Inverte o sprite
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}