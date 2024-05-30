using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteObject : MonoBehaviour, IExecute
{
    public GameGuideSO nextGuide;

    
    public void OnExecute()
    {
        if(PlayerManager.Instance.Player.equip.curEquip.gameObject.name.Contains(nextGuide.checkItem.name) && PlayerManager.Instance.Player.equip.curEquip != null)
        {
            PlayerManager.Instance.Player.guideEvent?.Invoke(nextGuide);

            this.gameObject.SetActive(false);   
        }        
    }

    
}
