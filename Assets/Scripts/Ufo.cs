

public class Ufo : EnemyBaseClass
{
    public int m_shieldPoints;
    internal override void TakeDamage(int m_damagePoints)
    {
        base.TakeDamage(m_damagePoints);
        //Handle shield damage first
    }

}
