using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public int souls;
    public TextMeshProUGUI uiTextSouls;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Reset();
    }
    private void Reset()
    {
        souls = 0;
        UpdateUI();
    }
    public void AddCoins(int amount = 1)
    {
        souls += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        uiTextSouls.text = souls.ToString();
    }
}
