using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class ShootEventTest : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public Transform PlayerSide;
    public void Start()
    {
        if (positionToShoot == null)
        {
            positionToShoot = GameObject.Find("ShootPosition").transform;
        }
        if (PlayerSide == null)
        {
            PlayerSide = GameObject.Find("PlayerObject").transform;
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