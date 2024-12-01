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

    [SerializeField] public int curHP;

    public System.Action onHealthChanged;

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

        DecreaseHealthBy(_damage);

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

    public virtual int GetMaxHP() {
        return maxHP.GetValue() + vitality.GetValue() *5;
    }

    protected virtual void DecreaseHealthBy(int _amount){
        curHP -= _amount;

        if (onHealthChanged != null){
            onHealthChanged();
        }
    }
}
