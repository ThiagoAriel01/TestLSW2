using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item")]
public class Item : ScriptableObject
{
    public string name;
    public int id;
    public bool stackable;
    public Sprite icon;
    public int price;
    public int sellPrice;
    public string clasS;
}
