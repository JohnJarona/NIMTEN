using TMPro;
using UnityEngine;

public sealed class UpgradeVisual : MonoBehaviour
{
    [SerializeField] private TMP_Text NameOfUpgradeText;
    [SerializeField] private TMP_Text OwnedText;
    [SerializeField] private TMP_Text CostText;
    [SerializeField] private TMP_Text PowerText;
    private UpgradeData m_MyData;
    private int m_TimesOwned;
    private float cost;
    private GameManager gameManager;
    public void TryBuyUpgrade()
    {
        if (gameManager.money >= cost)
        {
            switch (m_MyData.upgradeType)
            {
                case UpgradeType.autoclick:
                    gameManager.AddCPS(m_MyData.DataPower);
                    break;
                case UpgradeType.superclick:
                    gameManager.AddClickPower(m_MyData.DataPower);
                    break;
            }
            gameManager.AddMoney(-cost);
            m_TimesOwned++;
            UpdateOwnedText();
            cost = cost * 1.1f;
            UpdateCostText();
        }

    }
    public void Setup(GameManager gm, UpgradeData data)
    {
        gameManager = gm;
        m_MyData = data;
        UpdateOwnedText();
        NameOfUpgradeText.text = data.NameOfUpgrade;
        cost = data.UpgradeCost;
        UpdateCostText();
        switch (data.upgradeType)
        {
            case UpgradeType.autoclick:
                PowerText.text = $"CPS: {data.DataPower}";
                break;
            case UpgradeType.superclick:
                PowerText.text = $"Power: {data.DataPower}";
                break;
        }
    }
    private void UpdateCostText()
    {
        CostText.text = $"{cost.ToString("F2")}$";
    }
    private void UpdateOwnedText()
    {
        OwnedText.text = $"Owned: {m_TimesOwned}";
    }
    
}
