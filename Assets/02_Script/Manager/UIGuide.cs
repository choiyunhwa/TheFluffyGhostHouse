using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIGuide : MonoBehaviour
{
    //Fix
    public GameGuideSO firstGuide;

    public GameObject content;
    public TextMeshProUGUI guide;

    Coroutine delay;

    private void Start()
    {
        Init();

        PlayerManager.Instance.Player.guideEvent += GetGuideData;
    }

    private void Init()
    {
        content.SetActive(true);
        guide.text = firstGuide.guideContents;
        delay = StartCoroutine(CoDelay());
    }

    public void GetGuideData(GameGuideSO guideData)
    {
        StopCoroutine(delay);
        content.SetActive(true);
        guide.text = guideData.guideContents;
        delay = StartCoroutine(CoDelay());
    }

    IEnumerator CoDelay()
    {
        yield return new WaitForSeconds(2f);
        content.SetActive(false);
    }
}
