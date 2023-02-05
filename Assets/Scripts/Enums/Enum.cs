public enum TargetSelectType
{
    MELEE,          //근접
    RANGE,          //원거리
    HIGH_HP,        //높은 HP
    LOW_HP,         //낮은 HP
    HIGH_OVERALL,   //높은 오버롤
    LOW_OVERALL     //낮은 오버롤
}

public enum FSMState
{
    IDLE = 0,
    MOVE,
    ATTACK,
    SKILL,
    //HIT, //넉백 , 스턴 등 관련된 효과에서 사용 //FSM 에서는 딱히 필요가 없어 보임.
    DEATH
}

public enum AttackType
{
    MELEE,      //근접 공격 (칼, 둔기, 창...)
    RANGE       //원거리 공격(활, 총, 마법.,...)
}
