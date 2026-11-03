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
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text moneyClickPowText;
    [SerializeField] private TMP_Text moneyCpsText;
    public void UpdateMoneyText(float value)
    {
        moneyText.text = $"{value.ToString("F2")}$";
    }
    public void UpdateMoneyClickPowerText(float value)
    {
        moneyClickPowText.text = $"Click power: {value.ToString("F2")}$";
    }
    public void UpdateMoneyCpsText(float value)
    {
        moneyCpsText.text = $"CPS: {value.ToString("F2")}$";
    }
}