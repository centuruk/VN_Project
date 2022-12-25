using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlot : Slot, IPointerEnterHandler, IPointerExitHandler
{
    public CardInfo info;

    private void Awake()
    {
        info.gameObject.SetActive(false);
    }

    public void SetCardActive(CardData data)
    {
        info.gameObject.SetActive(true);
        info.SetCardData(data);
    }

    public bool HasChildrenObject()
    {
        if (info.gameObject.activeSelf) return true;
        else return false;
    }

    //Drag 중 같은거 있는지확인하고 해제.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerDrag == null) return;
        if (!eventData.pointerDrag.GetComponent<CardInfo>()) return;

        CardInfo cardInfo = eventData.pointerDrag.GetComponent<CardInfo>();
        if (info.CompareCardInfo(cardInfo.data))
        {
            //행동 및 업데이트 현황 확인하고. 애니메이션 할지 안할지 결정,,
            Debug.Log("행동시작");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //행동 및 업데이트 현황 확인하고 애니메이션 할지 안할지 결정,..
        Debug.Log("행동 끝");
    }

    public override void SetCardDrop(CardData data)
    {
        //합치기시전.
        info.SetMergedData();
    }
}
