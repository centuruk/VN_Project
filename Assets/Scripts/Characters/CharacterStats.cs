using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//юс╫ц

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
        maxhp = hp;       
    }
}
