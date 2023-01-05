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
        //각 효과에 따른 타겟을 읽어오고 찾아옴.
        return actor;
    }

    //각 종류별 목적을 타겟을 들고옴.
    //근접공격(가장 가까운) 혹은 원거리(가장 먼)
    //가장 Hp가 높거나 혹은 낮은
    //오버롤 가장 높은 혹은 가장 낮은
}
