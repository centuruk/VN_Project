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
    NONE = 0,
    MOVE,
    ATTACK,
    SKILL,
    HIT,
    DEATH
}
