using TMPro;
using UnityEngine;

public sealed class UpgradeVisual : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameOfUpgradeText;
    [SerializeField] private TMP_Text _ownedText;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private TMP_Text _powerText;
    private UpgradeData _myData;
    private int _timesOwned;
    private float _cost;
    private GameManager _gameManager;
    public void TryBuyUpgrade()
    {
        float money = _gameManager.Money;
        if (money >= _cost)
        {
            switch (_myData.upgradeType)
            {
                case UpgradeType.cps:
                    _gameManager.SetCPS(_gameManager.CPS + _myData.DataPower);
                    break;
                case UpgradeType.clickPower:
                    _gameManager.SetClickPower(_gameManager.ClickPower + _myData.DataPower);
                    break;
            }
            _gameManager.SetMoney(money - _cost);
            _timesOwned++;
            UpdateOwnedText();
            _cost = _cost * 1.1f;
            SetCostText();
        }

    }
    public void Setup(GameManager gm, UpgradeData data)
    {
        _gameManager = gm;
        _myData = data;
        UpdateOwnedText();
        _nameOfUpgradeText.text = data.NameOfUpgrade;
        _cost = data.UpgradeCost;
        SetCostText();
        switch (data.upgradeType)
        {
            case UpgradeType.cps:
                _powerText.text = $"CPS: {data.DataPower}";
                break;
            case UpgradeType.clickPower:
                _powerText.text = $"Power: {data.DataPower}";
                break;
        }
    }
    private void SetCostText()
    {
        _costText.text = $"{_cost.ToString("F2")}$";
    }
    private void UpdateOwnedText()
    {
        _ownedText.text = $"Owned: {_timesOwned}";
    }
    
}
