using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public int damage;
    public int maxHP;

    [SerializeField] private int curHP;

    void Start() {
        curHP = maxHP;
    }

    public void TakeDamage(int _damage) {
        curHP -= _damage;
        if (curHP < 0) {
            //Die();
        }
    }

    private void Die() {
        throw new NotImplementedException();
    }
}
