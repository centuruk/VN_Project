using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//????

public class CharacterStats : MonoBehaviour
{
    public float hp;
    public float maxhp;

    public float attack;
    public float def;
    public float dex;

    public float attackSpeed;
    public float moveSpeed;

    public float attackRange;

    public TargetSelectType targetSelect = TargetSelectType.MELEE;

    void Start()
    {
        //??
        hp = 100;
        attack = 10;
        def = 10;
        dex = 10;
        attackSpeed = 1;
        moveSpeed = 5;

        maxhp = hp;       
    }
}
