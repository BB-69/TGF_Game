using UnityEngine;

[RequireComponent(typeof(CharacterComponent))]
public class HealthComponent : MonoBehaviour
{
    Logger log;
    private CharacterComponent character;
    public int currentHP { get; private set; }

    void Awake()
    {
        character = GetComponent<CharacterComponent>();
        currentHP = character.maxHP;

        log = new Logger("Health", character);
    }

    public void TakeDamage(int amount)
    {
        int reduced = Mathf.Max(amount - character.DEF, 0);
        currentHP -= reduced;
        currentHP = Mathf.Max(0, currentHP);

        log.Log($"{character.charName} took {reduced} damage! HP: {currentHP}");
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Min(currentHP, character.maxHP);
        log.Log($"{character.charName} healed {amount} HP! HP: {currentHP}");
    }
}
