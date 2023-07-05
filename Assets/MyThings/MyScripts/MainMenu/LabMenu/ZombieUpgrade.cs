using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieUpgrade : MonoBehaviour
{
    private int survivalTimeUpgradeCount;
    private int damageUpgradeCount;
    private int defenceUpgradeCount;
    private int speedUpgradeCount;

    [SerializeField] private TextMeshProUGUI survivalTimeText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI defenceText;
    [SerializeField] private TextMeshProUGUI speedText;

    private void Awake()
    {
        string startingPrice = UpdateUpgradePrice(0).ToString();
        survivalTimeText.SetText(startingPrice);
        damageText.SetText(startingPrice);
        defenceText.SetText(startingPrice);
        speedText.SetText(startingPrice);
    }
    public void ZombieUpgradeSurvivalTime()
    {
        survivalTimeUpgradeCount++;
        if(survivalTimeUpgradeCount <= 4)
        {
            int upgradePrice = UpdateUpgradePrice(survivalTimeUpgradeCount);
            if (Gold.Instance.GetGold() > upgradePrice)
            {
                ZombieData.IncreaseSurvivalTime(10);
                UpdateUpgradePriceText(upgradePrice, survivalTimeText);
                Gold.Instance.RemoveGold(upgradePrice);
            }
        }

        survivalTimeText.SetText("MAX");
    }

    public void ZombieUpgradeDamage()
    {
        damageUpgradeCount++;
        if(damageUpgradeCount <= 4)
        {
            int upgradePrice = UpdateUpgradePrice(damageUpgradeCount);
            if (Gold.Instance.GetGold() > upgradePrice)
            {
                ZombieData.IncreaseAttack(10);
                UpdateUpgradePriceText(upgradePrice, damageText);
                Gold.Instance.RemoveGold(upgradePrice);
            }
            
        }
        else
        {
            damageText.SetText("MAX");
        }
    }

    public void ZombieUpgradeDefence()
    {
        defenceUpgradeCount++;
        if(defenceUpgradeCount <= 4)
        {
            int upgradePrice = UpdateUpgradePrice(defenceUpgradeCount);
            if (Gold.Instance.GetGold() > upgradePrice)
            {
                ZombieData.IncreaseDefence(10);
                UpdateUpgradePriceText(upgradePrice, defenceText);
                Gold.Instance.RemoveGold(upgradePrice);
            }
        }
        else
        {
            defenceText.SetText("MAX");
        }
    }

    public void ZombieUpgradeSpeed()
    {
        speedUpgradeCount++;
        if(speedUpgradeCount <= 4)
        {
            int upgradePrice = UpdateUpgradePrice(speedUpgradeCount);
            if (Gold.Instance.GetGold() > upgradePrice)
            {
                ZombieData.IncreaseSpeed(0.5f);
                UpdateUpgradePriceText(upgradePrice, speedText);
                Gold.Instance.RemoveGold(upgradePrice);
            }
        }
        else
        {
            speedText.SetText("MAX");
        }
    }

    private int UpdateUpgradePrice(int upgradequantity)
    {
        int price;
        //I know that using upgradequantity * 250 is much more efficient here, but I wanted to showcase how I can use switch statements.
        switch (upgradequantity)
        {
            case 1:
                price = 250;
                break;
            case 2:
                price = 500;
                break;
            case 3:
                price = 750;
                break;
            case 4:
                price = 1000;
                break;
            default:
                price = 150; // Default price if the upgrade count is greater than 4 (shouldn't happen in this case)
                break;
        }

        return price;
    }

    public void UpdateUpgradePriceText(int price, TextMeshProUGUI text)
    {
        text.SetText(price.ToString());
    }
}
