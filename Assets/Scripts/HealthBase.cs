using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public float Life = 10;
    public float _currentLife;
    public bool _isDead;
    public float delayToKill;
    public bool destroyOnKill;
    [SerializeField] private FlashColor _flashColor;

    private void Awake()
    {
        Init();
        if(_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = Life;
    }

    public void Damage(int damage)
    {
        if(_isDead) return;

        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }
        if (_flashColor != null)
        {
            _flashColor.Flash();
        }
    }

    private void Kill()
    {
        _isDead = true;

        if(destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
    }
}