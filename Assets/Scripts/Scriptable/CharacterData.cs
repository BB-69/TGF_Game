using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Data")]
public class CharData : ScriptableObject
{
    public string charName;
    public int atk, def, spd, maxhp;
    public Sprite skin;
}