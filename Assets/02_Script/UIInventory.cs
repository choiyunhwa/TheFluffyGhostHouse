using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public ItemSlot[] slots;
    public Transform slotCondition;

    public TextMeshProUGUI selectedItemName;

    private int curEquipIndex;

    private void Start()
    {
        slots = new ItemSlot[slotCondition.childCount];

        PlayerManager.Instance.Player.addItemEvent += AddItem;

        selectedItemName.text = string.Empty;

        for (int i =0; i < slots.Length; i++)
        {
            slots[i] = slotCondition.GetChild(i).GetComponent<ItemSlot>();
            slots[i].index = i;
            slots[i].Clear();
        }
    }

    public void AddItem()
    {
        ItemDataSO itemData = PlayerManager.Instance.Player.itemData;

        //Slot is EmptySlot
        ItemSlot emptySlot = GetEmptySlot();

        if(emptySlot != null)
        {
            emptySlot.item = itemData;
            UpdateUI();
            PlayerManager.Instance.Player.itemData = null;
            return;
        }

        PlayerManager.Instance.Player.itemData = null;
    }

    public void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }

    private ItemSlot GetEmptySlot() 
    {
        for(int i  = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                return slots[i];
            }
        }

        return null;
    }
}
