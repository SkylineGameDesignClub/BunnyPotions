using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public int Value;

    [TextArea]
    public string description;

    public GameObject prefab;
}
