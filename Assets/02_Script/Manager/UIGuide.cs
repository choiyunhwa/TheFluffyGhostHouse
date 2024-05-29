using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIGuide : MonoBehaviour
{
    public GameObject content;
    public TextMeshProUGUI guide;

    private void Start()
    {
        PlayerManager.Instance.Player.guideEvent += GetGuideData;
    }
    public void GetGuideData(GameGuideSO guideData)
    {   
        content.SetActive(true);
        guide.text = guideData.guideContents;
        StartCoroutine(CoDelay());
    }

    IEnumerator CoDelay()
    {
        yield return new WaitForSeconds(2f);
        content.SetActive(false);
    }
}
