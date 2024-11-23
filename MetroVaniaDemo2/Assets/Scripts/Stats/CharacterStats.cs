using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public Stat strength;
    public Stat damage;
    public Stat maxHP;

    [SerializeField] private int curHP;

    protected virtual void Start() {
        curHP = maxHP.GetValue();
    }

    public virtual void DoDamage(CharacterStats _target) {
        int totalDamage = damage.GetValue() + strength.GetValue();
        _target.TakeDamage(totalDamage);
    }

    public virtual void TakeDamage(int _damage) {
        curHP -= _damage;
        if (curHP < 0) {
            //Die();
        }
    }

    protected virtual void Die() {
        throw new NotImplementedException();
    }
}
