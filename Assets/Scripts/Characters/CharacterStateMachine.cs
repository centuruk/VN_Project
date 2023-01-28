using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    private Animator anim;

    private Rigidbody2D rb;
    private RaycastHit2D hit;
    private Ray2D ray;

    public FSMState state = FSMState.NONE;

    private Actor actor;
    private Actor target;
    private CharacterStats status;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        actor = GetComponent<Actor>();
        status = GetComponent<CharacterStats>();

        DetactedEnemy();
    }

    void Update()
    {
        
    }

    //타겟 찾기
    void DetactedEnemy()
    {
        target = actor.GetTarget(status.targetSelect);
        Debug.Log(this.gameObject.name + " >> " + target.gameObject.name);
    }

    void Idle()
    {
        //대기상태
    }

    void Move()
    {
        //이동
        //타겟을 따라감.
        //장애물 있으면 피해감.
    }

    void Attack()
    {
        //애니메이션 연동
    }

    void Hit()
    {
        //넉백
        //디버프
    }

    void Death()
    {
        //죽음 효과
    }
}
