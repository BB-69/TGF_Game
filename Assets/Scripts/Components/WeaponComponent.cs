using UnityEngine;
using Utils;

[RequireComponent(typeof(CharacterComponent))]
public class WeaponComponent : MonoBehaviour
{
    Logger log;
    private Camera cam;
    private CharacterComponent character;
    private Transform firePoint;
    public WeaponData currentWeapon;

    void Awake()
    {
        character = GetComponent<CharacterComponent>();
        log = new Logger("Weapon", character);

        cam = Camera.main;
        firePoint = transform.Find("FirePoint");
    }

    void Update()
    {
        if (currentWeapon == null) return;

        RotateTowardMouse();
    }

    void RotateTowardMouse()
    {
        firePoint.rotation = CustomHelper.GetRotationZ(
            firePoint.position,
            cam.ScreenToWorldPoint(Input.mousePosition)
        );
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
