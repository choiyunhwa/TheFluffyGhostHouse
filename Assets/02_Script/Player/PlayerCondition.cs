using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerCondition : MonoBehaviour, IDamageIble
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition mana { get { return uiCondition.mana; } }

    public void Die()
    {
        Debug.Log("ав╬З╢ы!");
    }
    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
    }

    public bool UseMana(float amount)
    {
        if (mana.curValue - amount < 0f)
        {
            return false;
        }
        mana.Subtract(amount);
        return true;
    }
}
