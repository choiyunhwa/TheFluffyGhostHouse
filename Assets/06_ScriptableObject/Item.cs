using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Equipable,
    Prop,
}

[CreateAssetMenu(fileName = "Item", menuName = "Items")]
public class Item : ScriptableObject
{
    public ItemType itemType;
    public GameObject itemPreb;
}
