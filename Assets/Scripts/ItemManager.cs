using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public SOInt souls;
    public TextMeshProUGUI uiTextSouls;
    public Slider slider;
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
        souls.value = 0;
        UpdateUI();
    }
    public void AddSouls(int amount = 1)
    {
        souls.value += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        uiTextSouls.text = souls.value.ToString();
    }
}
