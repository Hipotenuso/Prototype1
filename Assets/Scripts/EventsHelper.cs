using System.Collections.Generic;
using UnityEngine;

public class EventsHelper : MonoBehaviour
{
    //Junta todas as funções simples chamadas por eventos nas animações, podendo ser incrementado no prefab por chamar no Awake todas as dependências necessárias.

    [Header("ShootEvent")]
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public Transform PlayerSide;
    public List<AudioClip> audioClipListAttack;
    public List<AudioSource> audioSourceListAttack;
    private int _ondex = 0;

    [Header("JumpEvent")]
    public Player2 player2;
    public Animator _currentPlayer;
    public ParticleSystem particlesJump;
    public AudioSource audioSourceJump;
    public bool Groundeded;

    [Header("SoundEventWalk")]
    public List<AudioClip> audioClipList;
    public List<AudioSource> audioSourceList;
    private int _index = 0;

    public void Awake()
    {
        if (player2 == null)
        {
            player2 = FindAnyObjectByType<Player2>();
        }

        Groundeded = true;

        if (positionToShoot == null)
        {
            positionToShoot = GameObject.Find("ShootPosition").transform;
        }

        if (PlayerSide == null)
        {
            PlayerSide = GameObject.Find("PlayerObject").transform;
        }

        if (particlesJump == null)
        {
            particlesJump = GameObject.Find("Particles_Jump").GetComponent<ParticleSystem>();
        }
    }

    public void Shoot()
    {
        if (_ondex >= audioSourceListAttack.Count) _ondex = 0;
        var audioSourceAttack = audioSourceListAttack[_ondex];

        audioSourceAttack.clip = audioClipListAttack[Random.Range(0, audioClipListAttack.Count)];
        audioSourceAttack.Play();

        _ondex++;
        prefabProjectile.transform.localScale = new (PlayerSide.transform.localScale.x, 3);
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = PlayerSide.transform.localScale.x;
    }

    public void Jump()
    {
        if (audioSourceJump != null) audioSourceJump.Play();
    }

    private void Grounded()
    {
        _currentPlayer.SetBool("Jump", false);
        particlesJump.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        Groundeded = true;
    }

    public void WalkingOrRunning()
    {
        if (_index >= audioSourceList.Count) _index = 0;
        var audioSource = audioSourceList[_index];

        audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)];
        audioSource.Play();

        _index++;
    }


}
