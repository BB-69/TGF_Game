using Unity.Collections;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    public int index { get; private set; }
    public CharData data;

    public int ATK => data?.ATK ?? 0;
    public int DEF => data?.DEF ?? 0;
    public int maxHP => data?.maxHP ?? 0;
    public int SPD => data?.SPD ?? 0;

    public string charName => data?.charName ?? "Unknown";

    public bool HasData => data != null;

    void Awake()
    {
        index = EntityIndexSystem.GetNextEntityID();
    }
}
