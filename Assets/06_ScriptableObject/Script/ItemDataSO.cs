using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Equipable,
    Prop,
}

[CreateAssetMenu(fileName = "Item", menuName = "Items")]
public class ItemDataSO : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public ItemType itemType;
    public GameObject itemPreb;
    public Sprite icon;

    [Header("Equip")]
    public GameObject equipPrefab;
}
