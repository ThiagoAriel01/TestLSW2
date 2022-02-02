using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class SlotShopManager : MonoBehaviour, IPointerClickHandler
{
    // ITEM TIENDA
    public Item item;
    public ShopManager shopManager;
    public string name;
    public int id;
    public bool stackable;
    public int amount = 1;
    Image icon;
    public int price;
    public int sellPrice;
    public Text priceText;
    GameObject confirmPanel;

    void Awake()
    {
        stackable = item.stackable;
        price = item.price;
        sellPrice = item.sellPrice;
        icon = GetComponent<Image>();
        icon.sprite = item.icon;
        confirmPanel = shopManager.confirmContainer;
        priceText.text = price.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        confirmPanel.SetActive(true);
        confirmPanel.GetComponent<BuyConfirm>().id = id;
        confirmPanel.GetComponent<BuyConfirm>().buy = true;
    }

    public void ActualizeItem()
    {
        stackable = item.stackable;
        price = item.price;
        icon = GetComponent<Image>();
        icon.sprite = item.icon;
        priceText = GetComponentInChildren<Text>();
        priceText.text = price.ToString();
    }
}
