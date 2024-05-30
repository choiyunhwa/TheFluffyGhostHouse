using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public ItemSlot[] slots;
    public Transform slotCondition;
    public Transform slotChoiceIcon;

    public TextMeshProUGUI selectedItemName;

    private ItemDataSO selectedItem;
    private int selectedItemIndex = -1;

    private int curEquipIndex;

    private void Start()
    {
        slots = new ItemSlot[slotCondition.childCount];

        PlayerManager.Instance.Player.addItemEvent += AddItem;
        PlayerManager.Instance.Player.controller.inventoryEvent += SelectItem;
        PlayerManager.Instance.Player.guideClear += RemoeveSelectedItem;
        PlayerManager.Instance.Player.guideClear += UnEquip;

        ClearSelectedItemWindow();

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

    public void SelectItem()
    {
        selectedItemIndex++;

        if (selectedItemIndex >= slots.Length)
            selectedItemIndex = 0;

        slotChoiceIcon.position = new Vector3(slots[selectedItemIndex].transform.position.x, slotChoiceIcon.position.y, slotChoiceIcon.position.z);

        PlayerManager.Instance.Player.equip.UnEquip();
        if (slots[selectedItemIndex].item != null)
        {
            selectedItem = slots[selectedItemIndex].item;
            selectedItemName.text = selectedItem.itemName;
            
            PlayerManager.Instance.Player.equip.EquipNew(selectedItem);
        }

    }

    public void OnEquipButton()
    {
        switch (slots[selectedItemIndex].item.itemType)
        {
            case ItemType.Equipable:
                break;
            case ItemType.Prop:
                break;
        }
    }

    private void ClearSelectedItemWindow()
    {
        selectedItemName.text = string.Empty;
    }

    private void RemoeveSelectedItem()
    {
        Debug.Log(selectedItemIndex);
        if(slots[selectedItemIndex] != null)
        {
            selectedItem = null;
            slots[selectedItemIndex].item = null;

            ClearSelectedItemWindow();
        }
        UpdateUI();
    }

    private void UnEquip()
    {
        PlayerManager.Instance.Player.equip.UnEquip();
    }
}
