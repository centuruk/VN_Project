using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//효과적인 시스템 만들어 내기

public class CharacterStateMachine : MonoBehaviour
{
    private Animator anim;

    private Rigidbody2D rb;
    private RaycastHit2D hit;
    private Ray2D ray;
    private LayerMask mask;

    public FSMState state = FSMState.IDLE;

    private Actor actor;
    private Actor target;
    private CharacterStats status;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        actor = GetComponent<Actor>();
        status = GetComponent<CharacterStats>();

        mask = this.gameObject.layer;

        DetactedEnemy();
    }

    void Update()
    {
        if (status.hp <= 0) state = FSMState.DEATH;

        switch (state)
        {
            case FSMState.IDLE:         Idle();     break;
            case FSMState.MOVE:         Move();     break;
            case FSMState.ATTACK:       Attack();   break;
            case FSMState.SKILL:                    break;
            //case FSMState.HIT:          Hit();      break;
            case FSMState.DEATH:        Death();    break;
        }
    }

    //타겟 찾기
    void DetactedEnemy()
    {
        target = actor.GetTarget(status.targetSelect);
    }

    void Idle()
    {
        //대기 애니메이션 진행
        anim.SetBool("Attack", false);
        anim.SetBool("Run", false);

        //대기상태
        DetactedEnemy();

        //상태전환
        if (target == null) state = FSMState.IDLE;
        else state = FSMState.MOVE;
    }

    void Move()
    {
        //이동 애니메이션
        anim.SetBool("Attack", false);
        anim.SetBool("Run", true);

        //방향 잡기
        Vector2 targetPos = target.transform.position;
        Vector2 thisPos = transform.position;
        Vector2 dir = (targetPos - thisPos).normalized;

        //이동
        rb.velocity = dir * status.moveSpeed;

        //Z포지션 변경
        float yPos = transform.position.y;
        Vector3 reFreshPos = new Vector3(transform.position.x, transform.position.y, yPos);
        transform.position = reFreshPos;

        //장애물 있으면 피해감.
        //서로 캐릭터들끼리의 거리 유지.
        //당면 과제.

        //상태 전환
        if (target == null) state = FSMState.IDLE;
        else if (Vector2.Distance(targetPos, thisPos) <= status.attackRange) state = FSMState.ATTACK;
    }

    void Attack()
    {
        //이동을 멈춤
        rb.velocity = Vector2.zero;

        //애니메이션 연동
        anim.SetBool("Attack", true);
        anim.SetBool("Run", false);

        //상태 전환
        if (target == null) state = FSMState.IDLE;
        else if (Vector2.Distance(target.transform.position, this.transform.position) > status.attackRange) state = FSMState.MOVE;
    }

    void Hit()
    {
        //넉백
        //디버프
        anim.SetTrigger("Hit");
    }

    void Death()
    {
        //죽음 효과
        anim.SetTrigger("Die");
    }
}
