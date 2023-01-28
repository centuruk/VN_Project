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

    //Ÿ�� ã��
    void DetactedEnemy()
    {
        target = actor.GetTarget(status.targetSelect);
        Debug.Log(this.gameObject.name + " >> " + target.gameObject.name);
    }

    void Idle()
    {
        //������
    }

    void Move()
    {
        //�̵�
        //Ÿ���� ����.
        //��ֹ� ������ ���ذ�.
    }

    void Attack()
    {
        //�ִϸ��̼� ����
    }

    void Hit()
    {
        //�˹�
        //�����
    }

    void Death()
    {
        //���� ȿ��
    }
}
