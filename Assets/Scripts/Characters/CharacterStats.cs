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
        //юс╫ц Random Point
        hp = Random.Range(80, 120);
        attack = def = dex = Random.Range(5, 10);
        attackSpeed = 1;
        moveSpeed = 2;
        attackRange = (attackType == AttackType.MELEE) ? 1 : 4;

        maxhp = hp;       
    }

    public float GetOverRoll()
    {
        float overRoll = (attack + def + dex) / 3;
        return overRoll;
    }
}
