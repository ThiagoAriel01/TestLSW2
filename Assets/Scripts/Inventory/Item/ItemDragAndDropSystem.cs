using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDragAndDropSystem : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject dragIcon;
    public ShopManager shopManager;
    RectTransform iconTransform;
    Image itemIconImage;
    GameObject confirmPanel;


    void Awake()
    {
        confirmPanel = shopManager.confirmContainer;
    }

    void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = dragIcon.GetComponent<RectTransform>();
        itemIconImage = dragIcon.GetComponent<Image>();
    }

    void Update()
    {
        if (dragIcon.activeInHierarchy)
        {
            iconTransform.position = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    ItemSpawnManager.instance.SpawnItem(itemSlot.item, itemSlot.count);
                    itemSlot.Clear();
                    dragIcon.SetActive(false);
                }
            }
        }
    }

    internal void OnClick(ItemSlot itemSlot)
    {
        if (shopManager.gameObject.activeInHierarchy)
        {
            confirmPanel.SetActive(true);
            confirmPanel.GetComponent<BuyConfirm>().id = itemSlot.item.id;
            confirmPanel.GetComponent<BuyConfirm>().item = itemSlot.item;
            confirmPanel.GetComponent<BuyConfirm>().buy = false;
        }
        else
        {
            if (this.itemSlot.item == null)
            {
                this.itemSlot.Copy(itemSlot);
                itemSlot.Clear();
            }
            else
            {
                Item item = itemSlot.item;
                int count = itemSlot.count;

                itemSlot.Copy(this.itemSlot);
                this.itemSlot.Set(item, count);
            }
        }
        
        UpdateIcon();
    }

    public Item Get()
    {
        return itemSlot.item;
    }

    void UpdateIcon()
    {
        if (itemSlot.item == null)
        {
            dragIcon.SetActive(false);
        }
        else
        {
            dragIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
