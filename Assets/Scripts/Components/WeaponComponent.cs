using UnityEngine;
using Utils;

[RequireComponent(typeof(CharacterComponent))]
public class WeaponComponent : MonoBehaviour
{
    Logger log;
    private CharacterComponent character;
    public Transform firePoint { get; private set; }
    public WeaponData currentWeapon;

    void Awake()
    {
        character = GetComponent<CharacterComponent>();
        log = new Logger("Weapon", character);

        firePoint = transform.Find("FirePoint");
    }

    public void UseWeapon()
    {
        if (currentWeapon?.behaviorScript is IWeaponBehavior behavior)
        {
            behavior.Use(gameObject); // Pass in the character/player
        }
        else
        {
            log.Warn("No usable behavior on weapon!");
        }
    }

    public void EquipWeapon(WeaponData weapon)
    {
        currentWeapon = weapon;
        log.Log($"Equipped {weapon.itemName}");
    }
}
