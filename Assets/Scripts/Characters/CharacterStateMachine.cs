using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ȿ������ �ý��� ����� ����

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

    //Ÿ�� ã��
    void DetactedEnemy()
    {
        target = actor.GetTarget(status.targetSelect);
    }

    void Idle()
    {
        //��� �ִϸ��̼� ����
        anim.SetBool("Attack", false);
        anim.SetBool("Run", false);

        //������
        DetactedEnemy();

        //������ȯ
        if (target == null) state = FSMState.IDLE;
        else state = FSMState.MOVE;
    }

    void Move()
    {
        //�̵� �ִϸ��̼�
        anim.SetBool("Attack", false);
        anim.SetBool("Run", true);

        //���� ���
        Vector2 targetPos = target.transform.position;
        Vector2 thisPos = transform.position;
        Vector2 dir = (targetPos - thisPos).normalized;

        //�̵�
        rb.velocity = dir * status.moveSpeed;

        //Z������ ����
        float yPos = transform.position.y;
        Vector3 reFreshPos = new Vector3(transform.position.x, transform.position.y, yPos);
        transform.position = reFreshPos;

        //��ֹ� ������ ���ذ�.
        //���� ĳ���͵鳢���� �Ÿ� ����.
        //��� ����.

        //���� ��ȯ
        if (target == null) state = FSMState.IDLE;
        else if (Vector2.Distance(targetPos, thisPos) <= status.attackRange) state = FSMState.ATTACK;
    }

    void Attack()
    {
        //�̵��� ����
        rb.velocity = Vector2.zero;

        //�ִϸ��̼� ����
        anim.SetBool("Attack", true);
        anim.SetBool("Run", false);

        //���� ��ȯ
        if (target == null) state = FSMState.IDLE;
        else if (Vector2.Distance(target.transform.position, this.transform.position) > status.attackRange) state = FSMState.MOVE;
    }

    void Hit()
    {
        //�˹�
        //�����
        anim.SetTrigger("Hit");
    }

    void Death()
    {
        //���� ȿ��
        anim.SetTrigger("Die");
    }
}
