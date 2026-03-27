public class Health : DamageableResource, IRrecoverable
{
    public int GetHeal(int healVaule)
    {
        if (value >= maxValue) return maxValue;

        value += healVaule;
        return value;
    }
}
