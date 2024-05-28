using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemDataSO item;

    public Image icon;

    public int index;

    public void Set()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
    }

    public void Clear()
    {
        item = null;
        icon.gameObject.SetActive(false);
    }
}
