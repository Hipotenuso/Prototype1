using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;
    public float attackDuration;
    public HealthBase healthBase;
    public float tdDelay;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();
        if (health != null)
        {
            health.Damage(damage);
            //PlayAttackAnimation();
        }
    }
    //private void PlayAttackAnimation()
    //{
        //animator.SetBool("Light_Attack", true);
        //StartCoroutine(ResetAttackAnimation());
    //}
    //private IEnumerator ResetAttackAnimation()
    //{
        //yield return new WaitForSeconds(attackDuration);
        //animator.SetBool("Light_Attack", false);
    //}
    public void Damage(int amount)
    {
        healthBase.Damage(amount);
        animator.SetBool("TDamage", true);
        StartCoroutine(TDamageReset());
    }

    private IEnumerator TDamageReset()
    {
        yield return new WaitForSeconds(tdDelay);
        animator.SetBool("TDamage", false);
    }
}