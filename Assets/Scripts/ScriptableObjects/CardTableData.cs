using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDatas", menuName = "ScriptableObjects/CardDatas")]
public class CardTableData : ScriptableObject
{
    [SerializeField]
    List<CardData> cardDatas = new List<CardData>();
    public int CardCount { get { return cardDatas.Count; } }    
    public CardData GetCardData(int index) => cardDatas[index];
    public CardData GetRandomCardData() => cardDatas[Random.Range(0, CardCount)];
}
