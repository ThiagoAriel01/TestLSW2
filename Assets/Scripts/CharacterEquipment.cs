using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    private Item armorItem;
    private Item shoesItem;

    public Item GetArmorItem()
    {
        return armorItem;
    }
    public Item GetShoesItem()
    {
        return shoesItem;
    }
    public void SetArmorItem(Item armorItem)
    {
        this.armorItem = armorItem;
    }
    public void SetShoesItem(Item shoesItem)
    {
        this.shoesItem = shoesItem;
    }
}
