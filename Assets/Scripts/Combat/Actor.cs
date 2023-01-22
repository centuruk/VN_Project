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
        //Actors???? ?????? ????????
        return this;
    }

    private void OnDisable()
    {
        Actors.RemovedActors(this);   
    }
}
