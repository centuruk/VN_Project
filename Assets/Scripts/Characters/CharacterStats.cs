using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float hp;
    public float maxhp;

    public float attack;
    public float def;
    public float dex;

    public float attackSpeed;
    public float moveSpeed;

    public AttackType attackType = AttackType.MELEE;
    public float attackRange;
    
    public TargetSelectType targetSelect = TargetSelectType.MELEE;

    void Start()
    {
        maxhp = hp;       
    }

    public float GetOverRoll()
    {
        float overRoll = (attack + def + dex) / 3;
        return overRoll;
    }
}
