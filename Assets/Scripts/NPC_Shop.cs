using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Shop : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;

    void Awake()
    {
        shopPanel.SetActive(false);    
    }

    public void Show()
    {
        shopPanel.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopPanel.SetActive(false);
        }
    }
}
