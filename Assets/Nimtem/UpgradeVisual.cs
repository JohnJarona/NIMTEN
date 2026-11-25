using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class UpgradeVisual : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameOfUpgradeText;
    [SerializeField] private TMP_Text _ownedText;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private TMP_Text _powerText;
    [SerializeField] private RectTransform _effectRect;
    [SerializeField] private Image _effectImg;
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

            _effectRect.localScale = Vector2.one;

            _effectImg.color = Color.white;
            _effectRect.DOKill();
            _effectRect.DOScale(1.5f, 1f);
            _effectImg.DOKill();
            _effectImg.DOFade(0, 1f);
        }
        else
        {
            _costText.color = Color.red;
            _costText.DOKill();
            _costText.DOColor(Color.white, 1f);
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
