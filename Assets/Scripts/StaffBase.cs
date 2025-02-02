using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class StaffBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float shootDelay;
    public float shootDelay2;
    private Coroutine _currentCoroutine;
    public Transform PlayerSide;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
        }
    }
    IEnumerator StartShoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(shootDelay);
            Shoot();
            yield return new WaitForSeconds(shootDelay2);
        }
    }


    public void Shoot()
    {
        prefabProjectile.transform.localScale = new (PlayerSide.transform.localScale.x, 3);
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = PlayerSide.transform.localScale.x;
    }
}
