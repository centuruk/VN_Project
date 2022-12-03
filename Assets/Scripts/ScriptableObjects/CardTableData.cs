using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTableData : ScriptableObject
{
    [SerializeField]
    List<CardData> cardDatas = new List<CardData>();
}
