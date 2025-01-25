using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Ease ease;
    public Rigidbody2D myRigidbody;

    [Header("Player Moviment Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float _CurrentSpeed;
    public float JumpForce;
    public float JumpDuration;
    public float playerside;
    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    public void Update()
    {
        PlayerMoviment();
        PlayerJump();
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
            myRigidbody.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("Walk", true);
            playerside = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.linearVelocity = new Vector2(-_CurrentSpeed, myRigidbody.linearVelocity.y);
            myRigidbody.transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("Walk", true);
            playerside = -1;
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        if (myRigidbody.linearVelocity.x > 0)
        {
            myRigidbody.linearVelocity += friction;
        }
        else if (myRigidbody.linearVelocity.x < 0)
        {
            myRigidbody.linearVelocity -= friction;
        }
    }

    public void PlayerJump()
    {
        if (playerside != -1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.linearVelocity = Vector2.up * JumpForce;
                myRigidbody.transform.DOScale(new Vector2(.7f, 1.3f), JumpDuration).SetLoops(2, LoopType.Yoyo);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.linearVelocity = Vector2.up * JumpForce;
                myRigidbody.transform.DOScale(new Vector2(-.7f, 1.3f), JumpDuration).SetLoops(2, LoopType.Yoyo);
            }
        }
    }
}
