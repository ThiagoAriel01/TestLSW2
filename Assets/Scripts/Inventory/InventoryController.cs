using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject inventory;

    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            inventory.SetActive(!inventory.activeInHierarchy);
        }
    }
}
