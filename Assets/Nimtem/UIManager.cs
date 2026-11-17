using System.Collections.Generic;
using TMPro;
using UnityEngine;

public sealed class UIManager : MonoBehaviour
{
    [SerializeField] private UpgradeVisual _upgradeVisualPrefab;
    [SerializeField] private RectTransform _upgradesRoot;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private TMP_Text _moneyClickPowText;
    [SerializeField] private TMP_Text _moneyCpsText;
    public void SetupAllUpgrades(UpgradeData[] allUpgrades)
    {
        foreach(UpgradeData upgradeData in allUpgrades)
        {
            UpgradeVisual upgradeObj = GameObject.Instantiate(_upgradeVisualPrefab, _upgradesRoot);
            upgradeObj.Setup(_gameManager, upgradeData);
        }
    }

    public void SetMoneyText(float value)
    {
        _moneyText.text = $"{value.ToString("F2")}$";
    }
    public void SetClickPowerText(float value)
    {
        _moneyClickPowText.text = $"Click power: {value.ToString("F2")}$";
    }
    public void SetCpsText(float value)
    {
        _moneyCpsText.text = $"CPS: {value.ToString("F2")}$";
    }
}