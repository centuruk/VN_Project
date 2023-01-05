using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //캐릭터 속도를 읽어오고 이동 스피드 적용
    public float movementSpeed = 5.0f;

    //Components
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
}
