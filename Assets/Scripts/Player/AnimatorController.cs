using UnityEditor.Rendering;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;
    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    
    public void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("WalkR", true);
        }
        else 
        {
            animator.SetBool("WalkR", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("WalkL", true);
        }
        else animator.SetBool("WalkL", false);
    }
}
