using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public enum ActorType
    {
        CHARACTER, MONSTER
    }
    public ActorType type = ActorType.CHARACTER;
    private Actors Actors = new Actors();

    private void OnEnable()
    {
        Actors.RegistedActors(this);
    }

    private void Awake()
    {
        Actors = FindObjectOfType<Actors>();          
    }

    public Actor GetTarget(TargetSelectType type)
    {
        //Actors에서 타겟을 읽어오기
        return Actors.GetTarget(this, type);
    }
}
