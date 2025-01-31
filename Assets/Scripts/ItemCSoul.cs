using UnityEngine;

public class ItemCSoul : ItemCBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddSouls();
    }
}
