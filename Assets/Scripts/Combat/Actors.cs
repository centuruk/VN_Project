using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actors : MonoBehaviour
{
    private List<Actor> playerActor = new List<Actor>();
    private List<Actor> enemyActor = new List<Actor>();

    public void RegistedActors(Actor actor)
    {
        if (playerActor.Contains(actor) || enemyActor.Contains(actor)) return;
            
        if(actor.type == Actor.ActorType.CHARACTER) playerActor.Add(actor);
        else enemyActor.Add(actor);
    }

    public Actor GetTarget(Actor actor, TargetSelectType type)
    {
        //Ÿ���� ���ٸ� ���ٰ� �޼����� ���������.
        if(playerActor.Count <= 0 || enemyActor.Count <= 0)
        {
            //������ ���¸� ������ ��ȯ
            return null;
        }

        //������ Ÿ���� ĳ�������� �ƴ��� Ȯ���ϰ� �迭�� ����.
        Actor[] actors = (actor.type == Actor.ActorType.CHARACTER)? enemyActor.ToArray() : playerActor.ToArray();

        Actor result = null;

        switch (type)
        {
            case TargetSelectType.MELEE:        result = GetAttackRangeTarget(actor, actors, false);    break;
            case TargetSelectType.RANGE:        result = GetAttackRangeTarget(actor, actors, true);     break;
            case TargetSelectType.HIGH_HP:      result = GetHpTarget(actor, actors, true);              break;
            case TargetSelectType.LOW_HP:       result = GetHpTarget(actor, actors, false);             break;
            case TargetSelectType.HIGH_OVERALL: result = GetOverRollTarget(actor, actors, true);        break;
            case TargetSelectType.LOW_OVERALL:  result = GetOverRollTarget(actor, actors, false);       break;
            default:                            result = GetNearTarget(actor, actors);                  break;
        }
        
        return result;
    }

    //�� ������ ������ Ÿ���� ����.
    //1. ���� ����� Ÿ��
    private Actor GetNearTarget(Actor a, Actor[] actors)
    {
        float dist = Mathf.Infinity;
        Actor result = null;
        for(int i = 0; i < actors.Length; i++)
        {
            float d = Vector2.Distance(a.transform.position, actors[i].transform.position);
            if (d <= dist)
            {
                dist = d;
                result = actors[i];
            }
        }
        return result;
    }

    //2. ���� Hp�� ���ų� Ȥ�� ����
    //������ ��ü�� ���ü� ����.
    private Actor GetHpTarget(Actor a, Actor[] actors, bool high)
    {
        Actor result = null;
        List<Actor> targets = new List<Actor>();
        float compare = (high) ? 0 : Mathf.Infinity;

        //���ϱ�
        for (int i = 0; i < actors.Length; i++)
        {
            float getHp = actors[i].GetComponent<CharacterStats>().hp;
            
            if (high)
            {
                if (getHp > compare)
                {
                    compare = getHp;
                    result = actors[i];
                    targets.Clear();
                }
                else if (getHp == compare)
                {
                    compare = getHp;
                    targets.Add(actors[i]);
                }
            }
            else
            {
                if (getHp < compare)
                {
                    compare = getHp;
                    result = actors[i];
                    targets.Clear();
                }
                else if (getHp == compare)
                {
                    compare = getHp;
                    targets.Add(actors[i]);
                }
            }

        }

        //������ ��ü���� ������ ���� ����� ��ü ã��
        if(targets.Count > 0) result = GetNearTarget(a, targets.ToArray());

        return result;
    }

    //3. ������ ���� ���� Ȥ�� ���� ���� (��ų� ���ϰų�)
    private Actor GetOverRollTarget(Actor a, Actor[] actors, bool high)
    {
        Actor result = null;
        List<Actor> targets = new List<Actor>();
        float compare = (high) ? 0 : Mathf.Infinity;

        for (int i = 0; i < actors.Length; i++)
        {
            float over = actors[i].GetComponent<CharacterStats>().GetOverRoll();

            if (high)
            {
                if(over > compare)
                {
                    compare = over;
                    result = actors[i];
                    targets.Clear();
                }
                else if(over == compare)
                {
                    compare = over;
                    targets.Add(actors[i]);
                }
            }
            else
            {
                if (over < compare)
                {
                    compare = over;
                    result = actors[i];
                    targets.Clear();
                }
                else if (over == compare)
                {
                    compare = over;
                    targets.Add(actors[i]);
                }
            }
        }
        if(targets.Count > 0) result = GetNearTarget(a, targets.ToArray());
        return result;
    }


    //4. �ٰŸ� ������ �ϴ� ������ ���Ÿ� ������ �ϴ� ������.
    private Actor GetAttackRangeTarget(Actor a, Actor[] actors, bool isRange)
    {
        Actor result = null;
        List<Actor> targets = new List<Actor>();
        for (int i = 0; i < actors.Length; i++)
        {
            if (isRange)
            {
                if (actors[i].GetComponent<CharacterStats>().attackType == AttackType.RANGE)
                    targets.Add(actors[i]);
            }
            else
            {
                if (actors[i].GetComponent<CharacterStats>().attackType == AttackType.MELEE)
                    targets.Add(actors[i]);
            }
        }

        if(targets.Count > 0)
        {
            result = GetNearTarget(a, targets.ToArray());
        }

        return result;
    }

    public void RemovedActor(Actor actor)
    {
        if(playerActor.Contains(actor) || enemyActor.Contains(actor))
        {
            if (actor.type == Actor.ActorType.CHARACTER) playerActor.Remove(actor);
            else enemyActor.Remove(actor);
        }
    }
}
