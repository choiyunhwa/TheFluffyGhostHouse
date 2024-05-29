using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition mana { get { return uiCondition.health; } }

    public void Die()
    {
        Debug.Log("ав╬З╢ы!");
    }
}
