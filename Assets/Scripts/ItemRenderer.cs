using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemRenderer : MonoBehaviour
{
    public Item item;
        
    private SpriteRenderer itemRenderer;
    private void Awake()
    {
        itemRenderer = GetComponent<SpriteRenderer>();
        itemRenderer.sprite = item.sprite;
    }
}
