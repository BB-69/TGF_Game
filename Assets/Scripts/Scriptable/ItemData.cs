using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite[] frames;
    public int value; // damage, heal, etc.
    public ItemType itemType;

    public bool isStackable = true;

    public enum ItemType
    {
        Weapon,
        Consumable,
        KeyItem
    }

    public AudioClip SFX;
}
