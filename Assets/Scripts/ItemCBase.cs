using Unity.VisualScripting;
using UnityEngine;

public class ItemCBase : MonoBehaviour
{
    public Animator animator;
    public string compareTag = "Tag";
    public float delayToDesapear;

    [Header("Sounds")]
    public AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        OnCollect();
        animator.SetBool("Desapear", true);
        Destroy(gameObject, delayToDesapear);
    }
    protected virtual void OnCollect()
    {
        if (audioSource != null) audioSource.Play();
    }
}