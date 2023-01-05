using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ���� �ΰ����� �����

public class PlayerController : MonoBehaviour
{
    [SerializeField]Stats stat;

    //Custom Components
    Actor actor;
    Movement movement;

    //Components
    Animator animator;

    public FSMState state = FSMState.NONE;

    private void OnEnable()
    {
        
    }

    void Start()
    {
        actor = GetComponent<Actor>();
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        
    }
}
