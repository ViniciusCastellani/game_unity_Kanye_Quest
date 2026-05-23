using UnityEngine;

public class movimento_jogador : MonoBehaviour
{
    public float velocidade;
    private Rigidbody2D jogadorRB;
    private float horizontal;
    void Start()
    {
        jogadorRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        CapturarInputs();
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
}