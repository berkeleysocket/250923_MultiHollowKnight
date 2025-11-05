using UnityEngine.UIElements.Experimental;

public interface ILife
{
    public void GetDamage(sbyte value);
    public void Heal(sbyte value);
    public void Dead();
}
