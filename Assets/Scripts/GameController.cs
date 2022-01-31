using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Awake()
    {
        GameManager.instance.player = player;
    }
}
