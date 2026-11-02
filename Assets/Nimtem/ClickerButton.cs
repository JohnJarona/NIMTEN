using TMPro;
using UnityEngine;

public class ClickerButton : MonoBehaviour
{
    private int money;
    public TMP_Text moneyText;
    public void Start()
    {
        UpdateMoneyText();
    }
    public void Click()
    {
        money++;
        UpdateMoneyText();
    }
    public void UpdateMoneyText()
    {
        moneyText.text = $"{money}";
    }
}
