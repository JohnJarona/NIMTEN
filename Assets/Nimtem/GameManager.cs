using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] private UpgradeData[] AllUpgrades;
    [SerializeField] private UIManager uiManager;
    public float money { get; private set; }
    private float cps;
    private float clickPower = 1;
    public void AddCPS(float value)
    {
        ChangeCPS(cps + value);
    }
    public void ChangeCPS(float value)
    {
        cps = value;
        uiManager.UpdateMoneyCpsText(value);
    }
    public void AddClickPower(float value)
    {
        ChangeClickPower(clickPower + value);
    }
    public void ChangeClickPower(float value)
    {
        clickPower = value;
        uiManager.UpdateMoneyClickPowerText(value);
    }
    public void AddMoney(float value)
    {
        ChangeMoney(money + value);
    }
    public void ChangeMoney(float value)
    {
        money = value;
        uiManager.UpdateMoneyText(money);
    }
    public void Start()
    {
        ChangeClickPower(1);
        ChangeMoney(0);
        ChangeCPS(0);
        uiManager.SetupAllUpgrades(AllUpgrades);
        StartCoroutine(CoGameLoop());
    }
    public IEnumerator CoGameLoop()
    {
        while (true)
        {
            AddMoney(cps*33f/1000f);
            yield return new WaitForSeconds(33f/1000f);
        }
    }
    public void Click()
    {
        AddMoney(clickPower);
        uiManager.UpdateMoneyText(money);
    }

}