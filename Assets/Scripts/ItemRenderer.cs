using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemRenderer : MonoBehaviour
{
    public Item item;
        
    private SpriteRenderer itemRenderer;
    private MaterialPropertyBlock block;

    private float spriteOutline = 0;
    private bool isSpriteOutline = false;
    private void Awake()
    {
        block = new MaterialPropertyBlock();
        itemRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        itemRenderer.sprite = item.sprite;
        itemRenderer.GetPropertyBlock(block);
        SetRenderOutLine(0.0f);
    }

    private void Update()
    {
        if (spriteOutline != 0 && isSpriteOutline)
        {
            SetRenderOutLine(spriteOutline);
            spriteOutline = 0;
        }
        else if (isSpriteOutline)
        {
            SetRenderOutLine(0.0f);
            isSpriteOutline = false;
        }
    }
    public void SetSpriteOutline(float outlineThickness)
    {
        spriteOutline = outlineThickness;
        isSpriteOutline = true;
    }
    private void SetRenderOutLine(float outlineThickness)
    {
        block.SetFloat("_Outline", outlineThickness);
        itemRenderer.SetPropertyBlock(block);
    }
}
