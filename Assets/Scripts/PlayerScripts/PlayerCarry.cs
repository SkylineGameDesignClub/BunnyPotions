using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCarry : MonoBehaviour
{
    public SpriteRenderer itemRenderer;
    public Item carriedItem;
    private ItemRenderer nearItem = null;


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
    private void Update()
    {
        IdentifyItems();
    }

    void IdentifyItems()
    {
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
            closestItem.SetSpriteOutline(8.0f);
        }
        nearItem = closestItem;
    }
    void PickupItem()
    {
        // Find nearest item within range
        if (carriedItem)
        {
            DropItem();
            return;
        }

        if (nearItem != null)
        {
            nearItem.SetSpriteOutline(8.0f);
            PickupItem(nearItem.item);
            Destroy(nearItem.gameObject);
        }
    }

    void DropItem()
    {
        if (!carriedItem) return; 
        Instantiate(carriedItem.prefab, new Vector3(transform.position.x, transform.position.y,0), Quaternion.identity);
        itemRenderer.sprite = null;
        carriedItem = null;
    }

    void PickupItem(Item item)
    {
        itemRenderer.sprite = item.sprite;
        carriedItem = item;
    }

    private void OnDrawGizmosSelected()
    {
        if (!carriedItem)
        {
            //Draws PickUpRange of Items on Player 
            Gizmos.DrawWireSphere(transform.position, pickupRange);
        }
    }
}
