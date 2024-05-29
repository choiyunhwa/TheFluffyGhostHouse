using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Guide", menuName = "Guide")]
public class GameGuideSO : ScriptableObject
{
    public int num;
    public string guideContents;

    public GameObject checkItem;
}
