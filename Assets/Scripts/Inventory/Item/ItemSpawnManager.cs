using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager instance;

    [SerializeField] Transform character;
    Vector3 spawnerPosition;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        spawnerPosition = new Vector3(character.position.x, character.position.y - 0.12f, character.position.z);
    }

    [SerializeField] GameObject pickUpItemPrefab;
    
    public GameObject SpawnItem (Item item, int count)
    {
        Debug.Log("SpawnItem");
        GameObject o = Instantiate(pickUpItemPrefab, spawnerPosition, Quaternion.identity);
        o.GetComponent<PickUpItem>().Set(item, count);
        return o;
    }
}
