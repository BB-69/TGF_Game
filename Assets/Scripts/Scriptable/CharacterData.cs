using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Data")]
public class CharData : ScriptableObject
{
    public string charName;
    public int ATK;
    public int DEF;
    public int maxHP;
    public int SPD;
    public Sprite charSprite;
}