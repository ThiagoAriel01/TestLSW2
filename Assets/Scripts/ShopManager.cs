using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField]
    List<SlotShopManager> itemBuy;
    [SerializeField] Item item;
    [SerializeField] GameObject itemContainer;

    public GameObject confirmContainer;
    public GameObject insuficientContainer;

    void Start()
    {
        itemBuy = new List<SlotShopManager>();
        for (int i = 0; i < itemContainer.transform.childCount; i++)
        {
            itemBuy.Add(itemContainer.transform.GetChild(i).GetComponent<SlotShopManager>());
        }
        confirmContainer.SetActive(false);
        insuficientContainer.SetActive(false);
    }

  
    public void BuyItem(int id)
    {
        if (player.GetComponent<CharacterController2D>().money >= itemBuy[id-1].price)
        {
            player.GetComponent<CharacterController2D>().money -= itemBuy[id-1].price;
            GameManager.instance.inventoryContainer.Buy(itemBuy[id-1].item, 1);
            itemBuy[id].amount--;
        }
        else
        {
            insuficientContainer.SetActive(true);
        }
    }

    public void SellItem(int id)
    {
        item.id = id;
        player.GetComponent<CharacterController2D>().money += itemBuy[id-1].sellPrice;
        GameManager.instance.inventoryContainer.Remove(itemBuy[id - 1].item);
    }

}
