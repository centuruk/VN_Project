using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public string name;

    //ü��
    //���ݷ� //���°� ���
    //ġ��ŸȮ��
    //ġ��Ÿ������
    //��ų ����Ʈ (��ų ��밡�� Ƚ��)
    //��ø : ȸ���� //���߷� 
    //��ø ��ġ�� �̿��Ͽ� ĳ���� �̵� �ӵ�.

    //���ݼӵ� : �⺻�� 1 
}

public class PlayerableStat : Stats
{
    public uint level; //0���� ����
    
    //����ġ ���� �ϳ��� �ؾ��ϳ�?
}

public class MonsterStat : Stats
{
    public TargetSelectType type;
}