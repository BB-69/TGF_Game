public struct EnemyStats
{
    public EnemyStats(float maxHP, int ATK, int SPD, int DEF)
    {
        this.maxHP = maxHP;
        this.ATK = ATK;
        this.SPD = SPD;
        this.DEF = DEF;
    }
    public float maxHP;
    public int SPD;
    public int ATK;
    public int DEF;
}