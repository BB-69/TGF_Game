using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon Item")]
public class WeaponData : ItemData
{
    [Header("Weapon Menu")]
    public WeaponSubtype weaponSubtype;
    public float fireRate;
    public float range;

    public ScriptableObject behaviorScript;
}

public enum WeaponSubtype
{
    None,
    Pistol, // pew pew
    SubmachineGun, // Ratatata
    Sprayer, // shaaaaaaaaaaaaaaaaaa
    Splasher, // bshhhhh
    Grenade, // BOOOOOOOOM
}
