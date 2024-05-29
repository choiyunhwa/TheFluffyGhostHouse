using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public Equipment equip;

    public ItemDataSO itemData;
    public Action addItemEvent;
    public Action<GameGuideSO> guideEvent;

    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        equip = GetComponent<Equipment>();
    }
}
