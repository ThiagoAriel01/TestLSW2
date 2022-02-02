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
            Item itemCopy = Item.CreateItem(itemBuy[id - 1].item);
            GameManager.instance.inventoryContainer.Buy(itemCopy, 1);
            itemBuy[id].amount--;
        }
        else
        {
            insuficientContainer.SetActive(true);
        }
    }

    public void SellItem(Item item)
    {
        //Item item =GameManager.instance.inventoryContainer.slots[id];
        player.GetComponent<CharacterController2D>().money += item.sellPrice;
        GameManager.instance.inventoryContainer.Remove(item);
    }

}
