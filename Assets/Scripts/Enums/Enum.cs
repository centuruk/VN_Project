public enum TargetSelectType
{
    MELEE,          //����
    RANGE,          //���Ÿ�
    HIGH_HP,        //���� HP
    LOW_HP,         //���� HP
    HIGH_OVERALL,   //���� ������
    LOW_OVERALL     //���� ������
}

public enum FSMState
{
    NONE = 0,
    MOVE,
    ATTACK,
    SKILL,
    HIT, //�˹� , ���� �� ���õ� ȿ������ ���
    DEATH
}
