using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UpgradeData[] _allUpgades;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private RectTransform _clickerVisual;
    [SerializeField] private Image _clickerImageBlink;
    [SerializeField] private ClickParticle _clickParticlePrefab;
    [SerializeField] private RectTransform _clickParticleRoot;
    public float Money { get; private set; }
    public float ClickPower { get; private set; }
    public float CPS { get; private set; }
    private const float _glInterval = 33f/1000f;
    public void SetMoney(float val)
    {
        Money = val;
        _uiManager.SetMoneyText(val, CPS);
    }
    public void SetClickPower(float val)
    {
        ClickPower = val;
    }
    public void SetCPS(float val)
    {
        CPS = val;
        _uiManager.SetMoneyText(Money, val);
    }
    public void Click()
    {
        SetMoney(Money + ClickPower);
        _clickerVisual.DOKill();
        _clickerImageBlink.DOKill();
        _clickerVisual.eulerAngles = Vector3.zero;
        _clickerVisual.localScale = Vector3.one * 1.5f;
        _clickerImageBlink.color = Color.white;
        _clickerVisual.DOShakeRotation(1, 5, 25, 200).SetEase(Ease.OutCirc);
        _clickerVisual.DOScale(Vector3.one, 1f).SetEase(Ease.OutCirc);
        _clickerImageBlink.DOFade(0,0.5f).SetEase(Ease.OutCirc);

        ClickParticle particle = GameObject.Instantiate(_clickParticlePrefab, _clickParticleRoot);
        particle.transform.position = Mouse.current.position.ReadValue();
        particle.SetValue($"+{ClickPower:F2}$");
    }
    public void Start()
    {
        StartCoroutine(CoGameloop());
        _uiManager.SetupAllUpgrades(_allUpgades);
        SetMoney(0);
        SetCPS(0);
        SetClickPower(1);
    }
    public IEnumerator CoGameloop()
    {
        while(true)
        {
            SetMoney(Money + CPS * _glInterval);
            yield return new WaitForSeconds(_glInterval);
        }
    }
}