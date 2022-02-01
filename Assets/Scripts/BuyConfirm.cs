using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyConfirm : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] ShopManager shop;
    public int id;
    public bool buy = true;
    
    public void Confirm()
    {
        if (buy)
            shop.BuyItem(id);
        else
            shop.SellItem(id);
        this.gameObject.SetActive(false);
    }

    public void Cancel()
    {
        this.gameObject.SetActive(false);
        Debug.Log("Buy Canceled");
    }
}
