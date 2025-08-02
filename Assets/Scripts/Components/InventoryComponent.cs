using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public ItemData item;
    public int quantity;

    public InventorySlot(ItemData item, int qty = 1)
    {
        
        this.item = item;
        this.quantity = qty;
    }
}

public class InventoryComponent : MonoBehaviour
{
    Logger log;
    public List<InventorySlot> inventory = new();
    public ItemData testItem;

    void Start()
    {
        log = new Logger("Inventory", this);

        // TEST
        AddItem(testItem);
        UseItem(0);
    }

    public void AddItem(ItemData newItem)
    {
        if (newItem == null) return;

        if (newItem.isStackable)
        {
            InventorySlot slot = inventory.Find(s => s.item == newItem);
            if (slot != null)
            {
                slot.quantity++;
                log.Log($"Stacked: {newItem.itemName} x{slot.quantity}");
                return;
            }
        }

        inventory.Add(new InventorySlot(newItem));
        log.Log($"Added new item: {newItem.itemName}");
    }

    public void UseItem(int index)
    {
        if (index < 0 || index >= inventory.Count) return;

        InventorySlot slot = inventory[index];
        ItemData item = slot.item;

        switch (item.itemType)
        {
            case ItemData.ItemType.Consumable:
                GetComponent<HealthComponent>()?.Heal(item.value);
                break;

            case ItemData.ItemType.Weapon:
                HeldItemAnimation held = GetComponentInChildren<HeldItemAnimation>();
                held.SetSpriteAnimation("WaterGun");

                WeaponData weaponData = item as WeaponData;
                WeaponComponent weaponComp = GetComponent<WeaponComponent>();
                if (weaponData != null && weaponComp != null)
                {
                    weaponComp.EquipWeapon(weaponData);
                }

                break;

            default:
                log.Log($"{item.itemName} used!");
                break;
        }

        if (item.isStackable)
        {
            slot.quantity--;
            if (slot.quantity <= 0)
                inventory.RemoveAt(index);
        }
        else
        {
            inventory.RemoveAt(index);
        }
    }
}
