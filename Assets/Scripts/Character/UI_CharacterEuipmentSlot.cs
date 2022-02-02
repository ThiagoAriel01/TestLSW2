using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class UI_CharacterEuipmentSlot : MonoBehaviour, IPointerClickHandler
{
    public Image imageSlot;
    [SerializeField] int slotId;

    [SerializeField] GameObject valorianShoesContainer;
    [SerializeField] GameObject demonShoesContainer;
    [SerializeField] GameObject hermesShoesContainer;
    [SerializeField] GameObject goldenArmorContainer;
    [SerializeField] GameObject demonArmorContainer;
    [SerializeField] GameObject spectralArmorContainer;

    void Awake()
    {
        valorianShoesContainer.SetActive(false);
        demonShoesContainer.SetActive(false);
        hermesShoesContainer.SetActive(false);
        goldenArmorContainer.SetActive(false);
        demonArmorContainer.SetActive(false);
        spectralArmorContainer.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Item item = GameManager.instance.itemDragAndDrop.Get();
        if (item.clasS == "Armor" && slotId == 1)
        {
            SetImage(item);
        }
        if (item.clasS == "Shoes" && slotId == 2)
        {
            SetImage(item);
        }
        switch (item.id)
        {
            case 1:
                demonArmorContainer.SetActive(true);
                goldenArmorContainer.SetActive(false);
                spectralArmorContainer.SetActive(false);
                break;
            case 2:
                demonShoesContainer.SetActive(true);
                valorianShoesContainer.SetActive(false);
                hermesShoesContainer.SetActive(false);
                break;
            case 3:
                goldenArmorContainer.SetActive(true);
                demonArmorContainer.SetActive(false);
                spectralArmorContainer.SetActive(false);
                break;
            case 4:
                hermesShoesContainer.SetActive(true);
                valorianShoesContainer.SetActive(false);
                demonShoesContainer.SetActive(false);
                break;
            case 5:
                spectralArmorContainer.SetActive(true);
                goldenArmorContainer.SetActive(false);
                demonArmorContainer.SetActive(false);
                break;
            case 6:
                valorianShoesContainer.SetActive(true);
                demonShoesContainer.SetActive(false);
                hermesShoesContainer.SetActive(false);
                break;
        }
    } 

    public Image GetImage()
    {
        return imageSlot;
    }

    public void SetImage(Item imageItem)
    {
        imageSlot.sprite = imageItem.icon;
    }
}
