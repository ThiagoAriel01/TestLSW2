using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Data/Item Container")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    public void Add(Item item, int count = 1)
    {
        if (item.stackable)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if (itemSlot != null)
            {
                itemSlot.count += count;
            }
            else
            {
                itemSlot = slots.Find(x => x.item == null);
                if (itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else
        {
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (itemSlot != null)
            {
                itemSlot.item = item;
            }

        }
    }

    public void Buy(Item item, int count = 1)
    {
        ItemSlot itemSlot = slots.Find(x => x.item == null);
        if (itemSlot != null)
            itemSlot.item = item;
    }

    public void Remove(Item item)
    {
        ItemSlot itemSlot = slots.Find(x => x.item == null);
        if (itemSlot != null)
        {
            //itemSlot.item = item;
            //Debug.Log(item);
            //item = null;
            //item.icon = newIcono;
        }
            
    }
}

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count = 1;

    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    public void Clear()
    {
        item = null;
        count = 0;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }
}
