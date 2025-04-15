using UnityEngine;

[CreateAssetMenu(menuName = "Customer", fileName = "New Customer")]
public class Customer : ScriptableObject
{
    public string customerName;
    public string customerID;

    [TextArea]
    public string initialDialogue;

    public GameObject prefab;

}
