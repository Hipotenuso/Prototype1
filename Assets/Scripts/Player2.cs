using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class Player2 : MonoBehaviour
{
    [Header("References")]
    public Animator _currentPlayer;
    public Ease ease;
    public Rigidbody2D myRigidbody;
    public Slider slider;
    public SOPlayerSetup soPlayerSetup;
    //private void OnValidate()
    //{
        //if (_currentPlayer == null) _currentPlayer = GetComponent<Animator>();
    //}
    private void Awake()
    {
        _currentPlayer = Instantiate(soPlayerSetup.player, transform);
    }

    public void Update()
    {
        PlayerMoviment();
        PlayerJump();
        Attack();
        HealthBar();
    }
    public void PlayerMoviment()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            soPlayerSetup._CurrentSpeed = soPlayerSetup.speed;
            _currentPlayer.SetBool("Run", true);
        }
        else
        {
            soPlayerSetup._CurrentSpeed = soPlayerSetup.speed;
            _currentPlayer.SetBool("Run", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.linearVelocity = new Vector2(soPlayerSetup._CurrentSpeed, myRigidbody.linearVelocity.y);
            myRigidbody.transform.localScale = new Vector3(3, 3, 1);
            soPlayerSetup.Playerside = 1;
            _currentPlayer.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.linearVelocity = new Vector2(-soPlayerSetup._CurrentSpeed, myRigidbody.linearVelocity.y);
            myRigidbody.transform.localScale = new Vector3(-3, 3, 1);
            soPlayerSetup.Playerside = -1;
            _currentPlayer.SetBool("Walk", true);
        }
        else
        {
            _currentPlayer.SetBool("Walk", false);
        }
    }
    public void PlayerJump()
    {
        if (soPlayerSetup.Playerside == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _currentPlayer.SetBool("Jump", true);
                myRigidbody.linearVelocity = Vector2.up * soPlayerSetup.jumpForce;
                StartCoroutine(ResetJumpAnimation());
            }
        }   
        else if (soPlayerSetup.Playerside == -1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.linearVelocity = Vector2.up * soPlayerSetup.jumpForce;
                _currentPlayer.SetBool("Jump", true);
                StartCoroutine(ResetJumpAnimation());
            }
        }
    }
    public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentPlayer.SetBool("Light_Attack", true);
            StartCoroutine(ResetAttackAnimation());
        }
    }
    private IEnumerator ResetAttackAnimation()
    {
        yield return new WaitForSeconds(soPlayerSetup.attackDuration);
        _currentPlayer.SetBool("Light_Attack", false);
    }
    private IEnumerator ResetJumpAnimation()
    {
        yield return new WaitForSeconds(soPlayerSetup.jumpDuration);
        _currentPlayer.SetBool("Jump", false);  
    }
    private void HealthBar()
    {
        var Health = gameObject.GetComponent<HealthBase>();
        slider.value = Health._currentLife;
    }
}