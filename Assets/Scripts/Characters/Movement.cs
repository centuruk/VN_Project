using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //ĳ���� �ӵ��� �о���� �̵� ���ǵ� ����
    public float movementSpeed = 5.0f;

    //Components
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
}
