using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    public float playerSpeed;
    Rigidbody rb;
    Animator animator;

    void Update()
    {
        Move();
    }
    void Move()
    {
        if(gameManager.isDragging == true)
        {
            rb.velocity = Vector3.forward * playerSpeed;
            animator.SetBool("isMoving", true);
        }
    }

    void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnLose, OnLose);
        EventManager.AddHandler(GameEvent.OnWin, OnWin);
    }

    void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnLose, OnLose);
        EventManager.RemoveHandler(GameEvent.OnWin, OnWin);
    }

    void OnLose()
    {
        rb.velocity = Vector3.zero;
        animator.SetBool("isMoving", false);
    }

    void OnWin()
    {
        rb.velocity = Vector3.zero;
        animator.SetBool("isMoving", false);
    }

    void Awake() 
    {
        //playerSpeed = 2;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
}
