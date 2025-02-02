using UnityEngine;

public class JumpReset : MonoBehaviour
{
    public Player2 player2;
    public Animator _currentPlayer;
    public bool Groundeded;
    public void Awake()
    {
        if (player2 == null)
        {
            player2 = FindAnyObjectByType<Player2>();
        }
        Groundeded = true;
    }
    private void Grounded()
    {
        _currentPlayer.SetBool("Jump", false);
        Groundeded = true;
    }
}

