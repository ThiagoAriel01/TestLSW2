using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public ItemContainer inventoryContainer;
    public ItemDragAndDropSystem itemDragAndDrop;
    public DialogueSystem dialogueSystem;
    public NPC_Shop shopSystem;
    public ShopManager shopManager;
}
