using UnityEngine;

public class movimento_jogador : MonoBehaviour
{
    public float velocidade;
    private Rigidbody2D jogadorRB;
    private float horizontal;

    // Componentes para Animação
    private Animator anim;
    private movimento_pulo_jogador scriptPulo;

    void Start()
    {
        jogadorRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scriptPulo = GetComponent<movimento_pulo_jogador>();
    }

    void Update()
    {
        CapturarInputs();
        AtualizarAnimacoes();
    }

    void FixedUpdate()
    {
        Andar();
        Virar();
    }

    void CapturarInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void Andar()
    {
        jogadorRB.linearVelocity = new Vector2(horizontal * velocidade, jogadorRB.linearVelocity.y);
    }

    void Virar()
    {
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void AtualizarAnimacoes()
    {
        if (anim != null)
        {
            anim.SetFloat("velocidade", Mathf.Abs(jogadorRB.linearVelocity.x));

            if (scriptPulo != null)
            {
                anim.SetBool("esta_no_chao", scriptPulo.estaNoChao);
            }
        }
    }
}