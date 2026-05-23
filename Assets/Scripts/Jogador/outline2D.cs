using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Outline2D : MonoBehaviour
{
    [Header("Configuração do Outline")]
    public Color corOutline = Color.black;

    [Range(0f, 0.5f)]
    public float espessura = 0.02f;

    private SpriteRenderer spriteRenderer;
    private GameObject outlineObjeto;
    private SpriteRenderer outlineRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Cria objeto filho para o outline
        outlineObjeto = new GameObject("Outline");
        outlineObjeto.transform.parent = transform;
        outlineObjeto.transform.localPosition = Vector3.zero;
        outlineObjeto.transform.localRotation = Quaternion.identity;
        outlineObjeto.transform.localScale = Vector3.one;

        // Adiciona SpriteRenderer
        outlineRenderer = outlineObjeto.AddComponent<SpriteRenderer>();

        // Copia sprite original
        outlineRenderer.sprite = spriteRenderer.sprite;
        outlineRenderer.color = corOutline;

        // Define ordem para ficar atrás
        outlineRenderer.sortingLayerID = spriteRenderer.sortingLayerID;
        outlineRenderer.sortingOrder = spriteRenderer.sortingOrder - 1;

        AtualizarOutline();
    }

    void LateUpdate()
    {
        // Atualiza caso o sprite mude durante o jogo
        outlineRenderer.sprite = spriteRenderer.sprite;
    }

    void AtualizarOutline()
    {
        // Aumenta levemente o tamanho para criar o efeito
        outlineObjeto.transform.localScale = new Vector3(
            1.1f + espessura,
            1f + espessura,
            1f
        );
    }

    // Atualiza no Inspector em tempo real
    void OnValidate()
    {
        if (outlineObjeto != null)
        {
            outlineRenderer.color = corOutline;

            outlineObjeto.transform.localScale = new Vector3(
                1.1f + espessura,
                1f + espessura,
                1f
            );
        }
    }
}