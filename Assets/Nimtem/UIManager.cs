using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public sealed class UIManager : MonoBehaviour
{
    [SerializeField] private UpgradeVisual _upgradeVisualPrefab;
    [SerializeField] private RectTransform _upgradesRoot;
    [SerializeField] private RectTransform _shopRect;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private RectTransform _boarderRect;
    
    public void OpenShop()
    {
        _shopRect.DOKill();
        _shopRect.DOAnchorPosX(0, 1f).SetEase(Ease.OutCirc);
    }
    public void CloseShop(bool withAnim = false)
    {
        _shopRect.DOKill();
        _shopRect.DOAnchorPosX(-_shopRect.sizeDelta.x, withAnim ? 1f : 0f).SetEase(Ease.OutCirc);
    }
    public void SetupAllUpgrades(UpgradeData[] allUpgrades)
    {
        foreach(UpgradeData upgradeData in allUpgrades)
        {
            UpgradeVisual upgradeObj = GameObject.Instantiate(_upgradeVisualPrefab, _upgradesRoot);
            upgradeObj.Setup(_gameManager, upgradeData);
        }
    }

    public void SetMoneyText(float value, float cps)
    {
        string text = value.ToString("F2") + "$";
        if (cps != 0){
            text = $"{text} (+{cps:F2}$/s)";
        }
        _moneyText.text = text;
    }
    public void Start()
    {
        CloseShop(false);
        _boarderRect.anchoredPosition = new Vector2(0, _boarderRect.rect.height);
        _boarderRect.DOMoveY(_boarderRect.rect.height/2f, 1f).SetEase(Ease.OutCirc);
    }
}