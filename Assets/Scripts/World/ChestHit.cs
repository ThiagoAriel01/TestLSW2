using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestHit : Interactable
{
    //[SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 20;
    [SerializeField] float spread = 0.7f;
    [SerializeField] Item item;
    [SerializeField] GameObject openChest;
    [SerializeField] GameObject closeChest;

    void Start()
    {
        closeChest.SetActive(true);
        openChest.SetActive(false);
    }

    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            Item itemCopy = Item.CreateItem(item);
            GameObject go = ItemSpawnManager.instance.SpawnItem(itemCopy, 1);
            go.transform.position = position;
        }
        closeChest.SetActive(false);
        openChest.SetActive(true);
    }
}
