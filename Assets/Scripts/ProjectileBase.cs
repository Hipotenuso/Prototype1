using TMPro;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float currentSpeed;
    public float timeToDestroy;
    public Vector3 direction;
    public float side = 1;
    public int damageAmount;
    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            enemy.Damage(damageAmount);
            Destroy(gameObject);
        }
    }
}
