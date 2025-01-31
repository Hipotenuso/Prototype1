using UnityEngine;
using TMPro;

public class UIInGameManager : MonoBehaviour
{
    public TextMeshProUGUI uiTextSouls;

    public void UpdateTextSouls(string s)
    {
        uiTextSouls.text = s;
    }
}
