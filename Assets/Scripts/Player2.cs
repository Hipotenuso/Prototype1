using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;
using Unity.VisualScripting;
using System.Collections.Generic;

public class Player2 : MonoBehaviour
{
    [Header("References")]
    public EventsHelper eventsHelper;
    public Animator _currentPlayer;
    public Ease ease;
    public Rigidbody2D myRigidbody;
    public Slider slider;
    public SOPlayerSetup soPlayerSetup;
    public ParticleSystem particlesRun;
    public ParticleSystem particlesJump;
    private void Awake()
    {
        _currentPlayer = Instantiate(soPlayerSetup.player, transform);
        particlesJump.Stop();
        if (eventsHelper == null)
        {
            eventsHelper = FindAnyObjectByType<EventsHelper>();
        }
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
            soPlayerSetup._CurrentSpeed = soPlayerSetup.speedRun;
            _currentPlayer.SetBool("Run", true);
            if (!particlesRun.isPlaying)
            {
                particlesRun.Play();
            }
        }
        else
        {
            soPlayerSetup._CurrentSpeed = soPlayerSetup.speed;
            _currentPlayer.SetBool("Run", false);
            particlesRun.Stop(true, ParticleSystemStopBehavior.StopEmitting);
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
        if (eventsHelper.Groundeded != false)
        {
            if (soPlayerSetup.Playerside == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (!particlesJump.isPlaying)
                    {
                        particlesJump.Play(true);
                    }
                    _currentPlayer.SetBool("Jump", true);
                    myRigidbody.linearVelocity = Vector2.up * soPlayerSetup.jumpForce;
                    eventsHelper.Groundeded = false;
                    //StartCoroutine(ResetJumpAnimation());
                }
            }   
            else if (soPlayerSetup.Playerside == -1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (!particlesJump.isPlaying)
                    {
                        particlesJump.Play();
                    }
                    myRigidbody.linearVelocity = Vector2.up * soPlayerSetup.jumpForce;
                    _currentPlayer.SetBool("Jump", true);
                    eventsHelper.Groundeded = false;
                    //StartCoroutine(ResetJumpAnimation());
                }
            }
        }
    }
    public void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            _currentPlayer.SetBool("Light_Attack", true);
            StartCoroutine(ResetAttackAnimation());
        }
        else
        {
            _currentPlayer.SetBool("Light_Attack", false);
        }
    }
    private IEnumerator ResetAttackAnimation()
    {
        yield return new WaitForSeconds(soPlayerSetup.attackDuration);
    }
    //private IEnumerator ResetJumpAnimation()
    //{
        //yield return new WaitForSeconds(soPlayerSetup.jumpDuration);
        //_currentPlayer.SetBool("Jump", false);
        //particlesJump.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    //}
    private void HealthBar()
    {
        var Health = gameObject.GetComponent<HealthBase>();
        slider.value = Health._currentLife;
    }
}