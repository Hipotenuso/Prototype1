using UnityEngine;

public class ItemCHealth : ItemCBase
{
    public GameObject player;
    public float regen;
    protected override void OnCollect()
    {
        base.OnCollect();
        var life = player.GetComponent<HealthBase>();
        life._currentLife += regen;
    }
}
