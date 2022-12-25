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

    //Drag �� ������ �ִ���Ȯ���ϰ� ����.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerDrag == null) return;
        if (!eventData.pointerDrag.GetComponent<CardInfo>()) return;

        CardInfo cardInfo = eventData.pointerDrag.GetComponent<CardInfo>();
        if (info.CompareCardInfo(cardInfo.data))
        {
            //�ൿ �� ������Ʈ ��Ȳ Ȯ���ϰ�. �ִϸ��̼� ���� ������ ����,,
            Debug.Log("�ൿ����");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //�ൿ �� ������Ʈ ��Ȳ Ȯ���ϰ� �ִϸ��̼� ���� ������ ����,..
        Debug.Log("�ൿ ��");
    }

    public override void SetCardDrop(CardData data)
    {
        //��ġ�����.
        info.SetMergedData();
    }
}
