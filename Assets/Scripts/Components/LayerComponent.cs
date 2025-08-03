using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class LayerComponent : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool onlySetLocal = false;
    public int orderPadding = 0;

    public SpriteRenderer[] localSprite; // 1st member will be at the backest locally
    public int localPadding = 5;
    public int intervalPadding = 1;

    void Update()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null) return;
        }

        if (!onlySetLocal)
            spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100) + orderPadding;
        for (int i = 0; i < localSprite.Length; i++)
        {
            SpriteRenderer spr = localSprite[i];
            spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100)
                + orderPadding + localPadding + i * intervalPadding;
        }
    }
}