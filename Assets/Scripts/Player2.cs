using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using System.Collections;

public class Player2 : MonoBehaviour
{
    public Animator animator;
    public Ease ease;
    public Rigidbody2D myRigidbody;

    [Header("Player Moviment Setup")]
    public float speed;
    public float speedRun;
    public float _CurrentSpeed;
    public float JumpForce;
    public float JumpDuration;
    public float attackDuration;
    public int Playerside;
    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    public void Update()
    {
        PlayerMoviment();
        PlayerJump();
        Attack();
    }
    public void PlayerMoviment()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _CurrentSpeed = speedRun;
            animator.SetBool("Run", true);
        }
        else
        {
            _CurrentSpeed = speed;
            animator.SetBool("Run", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.linearVelocity = new Vector2(_CurrentSpeed, myRigidbody.linearVelocity.y);
            myRigidbody.transform.localScale = new Vector3(3, 3, 1);
            Playerside = 1;
            animator.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.linearVelocity = new Vector2(-_CurrentSpeed, myRigidbody.linearVelocity.y);
            myRigidbody.transform.localScale = new Vector3(-3, 3, 1);
            Playerside = -1;
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
    public void PlayerJump()
    {
        if (Playerside == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Jump", true);
                myRigidbody.linearVelocity = Vector2.up * JumpForce;
                StartCoroutine(ResetJumpAnimation());
            }
        }   
        else if (Playerside == -1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.linearVelocity = Vector2.up * JumpForce;
                animator.SetBool("Jump", true);
                StartCoroutine(ResetJumpAnimation());
            }
        }
    }
    public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Light_Attack", true);
            StartCoroutine(ResetAttackAnimation());
        }
    }
    private IEnumerator ResetAttackAnimation()
    {
        yield return new WaitForSeconds(attackDuration);
        animator.SetBool("Light_Attack", false);
    }
    private IEnumerator ResetJumpAnimation()
    {
        yield return new WaitForSeconds(JumpDuration);
        animator.SetBool("Jump", false);  
    }
}