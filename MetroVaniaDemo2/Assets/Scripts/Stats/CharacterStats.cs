using UnityEngine;

public class CharacterStats : MonoBehaviour {
    [Header("Main Stats")]
    public Stat strength;
    public Stat agility;
    public Stat intelligence;
    public Stat vitality;

    [Header("Defense Stats")]
    public Stat maxHP;
    public Stat armor;
    public Stat evasion;

    public Stat damage;

    [SerializeField] private int curHP;

    protected virtual void Start() {
        curHP = maxHP.GetValue();
    }

    public virtual void DoDamage(CharacterStats _target)
    {

        if (CanAvoidAttack(_target))
        {
            return;
        }

        int totalDamage = damage.GetValue() + strength.GetValue();
        totalDamage = CheckArmor(_target, totalDamage);
        _target.TakeDamage(totalDamage);
    }


    public virtual void TakeDamage(int _damage) {
        curHP -= _damage;
        if (curHP <= 0) {
            Die();
        }
    }

    protected virtual void Die() {
    }

    private int CheckArmor(CharacterStats _target, int totalDamage)
    {
        totalDamage -= _target.armor.GetValue();
        totalDamage = Mathf.Clamp(totalDamage, 0, int.MaxValue);
        return totalDamage;
    }

    public virtual bool CanAvoidAttack(CharacterStats _target){
        int totalEvasion = _target.evasion.GetValue() + _target.agility.GetValue();

        if (Random.Range(0, 100) < totalEvasion) {
            return true;
        }

        return false;
    }
}
