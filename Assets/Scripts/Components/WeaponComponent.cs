using UnityEngine;

[RequireComponent(typeof(CharacterComponent))]
public class WeaponComponent : MonoBehaviour
{
    Logger log;
    private CharacterComponent character;
    private Transform firePoint;
    public WeaponData currentWeapon;

    void Awake()
    {
        character = GetComponent<CharacterComponent>();
        log = new Logger("Weapon", character);

        firePoint = transform.Find("FirePoint");
    }

    void Update()
    {
        if (currentWeapon == null) return;

        RotateTowardMouse();
        if (Input.GetMouseButton(0)) UseWeapon();
    }

    void RotateTowardMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - firePoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);
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
