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
    IDLE = 0,
    MOVE,
    ATTACK,
    SKILL,
    //HIT, //�˹� , ���� �� ���õ� ȿ������ ��� //FSM ������ ���� �ʿ䰡 ���� ����.
    DEATH
}

public enum AttackType
{
    MELEE,      //���� ���� (Į, �б�, â...)
    RANGE       //���Ÿ� ����(Ȱ, ��, ����.,...)
}
