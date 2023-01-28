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
        //타겟이 없다면 없다고 메세지를 전해줘야함.
        if(playerActor.Count <= 0 || enemyActor.Count <= 0)
        {
            //액터의 상태를 대기모드로 전환
            return null;
        }

        //액터의 타입이 캐릭터인지 아닌지 확인하고 배열로 지정.
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

    //각 종류별 목적을 타겟을 들고옴.
    //1. 가장 가까운 타겟
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

    //2. 가장 Hp가 높거나 혹은 낮은
    //동일한 객체가 나올수 있음.
    private Actor GetHpTarget(Actor a, Actor[] actors, bool high)
    {
        float f = (high)? 0 : Mathf.Infinity;

        Actor result = null;
        
        //동일한 객체가 나왔을떄 담을 녀석
        List<Actor> indexs = new List<Actor>(); 

        //비교하기
        for (int i = 0; i < actors.Length; i++)
        {
            float getHp = actors[i].GetComponent<CharacterStats>().hp;
            if (high && getHp >= f)
            {
                f = getHp;
                result = actors[i];

                if (getHp == f) indexs.Add(actors[i]);
                else indexs.Clear();
            }
            else if(getHp <= f)
            {
                f = getHp;
                result = actors[i];

                if (getHp == f) indexs.Add(actors[i]);
                else indexs.Clear();
            }
        }

        //동일한 객체들이 있을때 가장 가까운 객체 찾기
        if(indexs.Count > 0)
        {
            Actor[] compare = indexs.ToArray();
            result = GetNearTarget(a, compare);
        }

        return result;
    }

    //3. 오버롤 가장 높은 혹은 가장 낮은 (쎄거나 약하거나)
    private Actor GetOverRollTarget(Actor a, Actor[] actors, bool high)
    {
        float f = (high) ? 0 : Mathf.Infinity;

        Actor result = null;
        List<Actor> targets = new List<Actor>();
        
        for (int i = 0; i < actors.Length; i++)
        {
            float over = actors[i].GetComponent<CharacterStats>().GetOverRoll();
            if (high && over >= f)
            {
                f = over;
                result = actors[i];

                if (f == over) targets.Add(actors[i]);
                else targets.Clear();
            }
            else if(over <= f)
            {
                f = over;
                result = actors[i];

                if (f == over) targets.Add(actors[i]);
                else targets.Clear();
            }
        }

        if(targets.Count > 0) result = GetNearTarget(a, targets.ToArray());

        return result;
    }


    //4. 근거리 공격을 하는 애인지 원거리 공격을 하는 애인지.
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
