using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemDataSO data;   
    public void OnInteract()
    {
        PlayerManager.Instance.Player.itemData = data;
        PlayerManager.Instance.Player.addItemEvent?.Invoke();
        Destroy(gameObject);
    }
}
