using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f, pickUpDistance = 1.5f, ttl = 10f, timer = 1f;

    public Item item;
    public int count = 1;

    void Start()
    {
        player = GameManager.instance.player.transform;
        
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            PickUp();
        }
    }

    void PickUp()
    {

        ttl -= Time.deltaTime;
        if (ttl < 0) { Destroy(gameObject); }

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (distance < 0.1f)
        {
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
                timer = 99;
            }
            Destroy(gameObject);
        }
    }
}
