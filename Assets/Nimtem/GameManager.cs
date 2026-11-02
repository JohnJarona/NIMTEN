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
        cps += value;
    }
    public void AddClickPower(float value)
    {
        clickPower += value;
    }
    public void AddMoney(float value)
    {
        money += value;
        uiManager.UpdateMoneyText(money);
    }
    public void Start()
    {
        clickPower = 1;
        uiManager.UpdateMoneyText(money);
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