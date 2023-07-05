using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldAmount : MonoBehaviour
{
    private TextMeshProUGUI goldQuantity;

    private void Awake()
    {
        goldQuantity = GetComponent<TextMeshProUGUI>();
        goldQuantity.SetText(Gold.Instance.GetGold().ToString());
        //subscribe to event gold spent
        //GoldManager.OnGoldUpdate += GoldManager_UpdateGoldAmount;
    }

    //private void GoldManager_UpdateGoldAmount(object sender, GoldManager.GoldAmountEventArgs e)
    //{
        //goldQuantity.SetText(e.gold.ToString());
    //}
}
