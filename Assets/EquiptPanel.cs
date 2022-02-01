using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquiptPanel : MonoBehaviour
{
    [SerializeField] GameObject equipPanel;

    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            equipPanel.SetActive(!equipPanel.activeInHierarchy);
        }
    }

}
