using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCarry : MonoBehaviour
{
    public SpriteRenderer itemRenderer;
    public Item carriedItem;

    public float pickupRange = 2f;

    private void Start()
    {
        itemRenderer.sprite = null;
        carriedItem = null;

        InputSystem.actions.Enable();
        InputSystem.actions.FindAction("Interact").performed += PickupItem;
    }

    private void OnDestroy()
    {
        InputSystem.actions.FindAction("Interact").performed -= PickupItem;
    }

    void PickupItem(InputAction.CallbackContext context)
    {
        PickupItem();
    }

    void PickupItem()
    {
        // Find nearest item within range
        var closestItem = null as ItemRenderer;
        var closestDistance = 999999999999999f;
        foreach (var item in Physics.OverlapSphere(transform.position, pickupRange))
        {
            var itemComponent = item.GetComponent<ItemRenderer>();
            var distance = Vector3.Distance(transform.position, item.transform.position);
            if (itemComponent != null && distance < closestDistance)
            {
                closestItem = itemComponent;
                closestDistance = distance;
            }
        }

        if (closestItem != null)
        {
            PickupItem(closestItem.item);
            Destroy(closestItem.gameObject);
        } else
        {
            DropItem();
        }
    }

    void DropItem()
    {
        if (!carriedItem) return; 
        Instantiate(carriedItem.prefab, transform.position, Quaternion.identity);
        itemRenderer.sprite = null;
        carriedItem = null;
    }

    void PickupItem(Item item)
    {
        itemRenderer.sprite = item.sprite;
        carriedItem = item;
    }
}
