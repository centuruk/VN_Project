using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actors : MonoBehaviour
{
    private List<Actor> actors = new List<Actor>();

    public void RegistedActors(Actor actor)
    {
        actors.Add(actor);
    }

    public Actor GetTarget(Actor actor, TargetSelectType type)
    {
        //�� ȿ���� ���� Ÿ���� �о���� ã�ƿ�.
        return actor;
    }

    //�� ������ ������ Ÿ���� ����.
    //��������(���� �����) Ȥ�� ���Ÿ�(���� ��)
    //���� Hp�� ���ų� Ȥ�� ����
    //������ ���� ���� Ȥ�� ���� ����
}
