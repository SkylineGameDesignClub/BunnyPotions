using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTalk : MonoBehaviour
{
    [SerializeField] [Range(0.0f,3.0f)] float customerInteractRadius = 1.5f;
    [SerializeField] DialougeManager dialougeManager;

    Customer selectedCustomer = null;
    void Start()
    {
        InputSystem.actions.FindAction("Talk").performed += TalkInteraction;
    }

    private void OnDestroy()
    {
        InputSystem.actions.FindAction("Talk").performed -= TalkInteraction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TalkInteraction(InputAction.CallbackContext context)
    {
        Debug.Log("Method Called");
        if (selectedCustomer != null && !dialougeManager.dialogueInProgress)
        {
            dialougeManager.DisableChildren();
            selectedCustomer = null;
            return;
        }
        float customerDistance = float.MaxValue;

        foreach (var customer in Physics.OverlapSphere(transform.position, customerInteractRadius))
        {
            CustomerBehaviour customerComponent = customer.GetComponent<CustomerBehaviour>();
            float dis = Vector3.Distance(transform.position, customer.transform.position);
            if (customerComponent != null && dis < customerDistance)
            {
                customerDistance = dis;
                selectedCustomer = customerComponent.customerData;
            }
        }
        if (selectedCustomer != null && !dialougeManager.dialogueInProgress)
        {
            dialougeManager.EnableChildren();
            Debug.Log("calling dialogue");
            Sprite customerSprite = selectedCustomer.prefab.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            dialougeManager.Dialouge(selectedCustomer.initialDialogue, customerSprite, selectedCustomer.customerName);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, customerInteractRadius);
    }
}
