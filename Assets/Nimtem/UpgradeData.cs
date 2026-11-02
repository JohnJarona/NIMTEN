using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade Data", menuName = "ClickerGame/")]
public sealed class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string NameOfUpgrade = "None";
    public float UpgradeCost = 10;
    public int DataPower = 1;
}
public enum UpgradeType
{
    autoclick,
    superclick
}