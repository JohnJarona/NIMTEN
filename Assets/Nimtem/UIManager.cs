using System.Collections.Generic;
using TMPro;
using UnityEngine;

public sealed class UIManager : MonoBehaviour
{
    [SerializeField] private UpgradeVisual UpgradeVisualPrefab;
    [SerializeField] private RectTransform UpgradesRoot;
    [SerializeField] private GameManager gameManager;
    public void SetupAllUpgrades(UpgradeData[] allUpgrades)
    {
        foreach(UpgradeData upgradeData in allUpgrades)
        {
            UpgradeVisual upgradeObj = GameObject.Instantiate(UpgradeVisualPrefab, UpgradesRoot);
            upgradeObj.Setup(gameManager, upgradeData);
        }
    }
    [SerializeField] private TMP_Text m_moneyText;
    public void UpdateMoneyText(float value)
    {
        m_moneyText.text = $"{value.ToString("F2")}$";
    }
}