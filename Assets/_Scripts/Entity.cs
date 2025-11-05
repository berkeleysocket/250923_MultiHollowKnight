using UnityEngine;

public abstract class Entity : MonoBehaviour, ILife
{
    //값을 주는 프로퍼티와 실제 값을 저장하는변수를 분리. 실제 값은 0 이상 sbyte 최대값 이하만큼 가지게 제한됨.
    private sbyte _life => (sbyte)Mathf.Clamp(_life, 0, sbyte.MaxValue);
    public sbyte Life { get; private set; }

    public void Dead()
    {
        Debug.Log($"{gameObject.name}이 죽었습니다.");
    }
    public void GetDamage(sbyte value)
    {
        Life -= value;
    }
    public void Heal(sbyte value)
    {
        Life += value;
    }
}
