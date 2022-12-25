using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [SerializeField] CardSlot[] slots;
    [Header("카드 데이터 테이블")]
    public CardTableData cardTable;
    
    //전반적인 게임 프로세싱에서 카드를 호출하는 것을 여기서 담당하자.
    [Header("임시"), Range(1, 13)]
    public int count = 0;

    private void Start()
    {

        for (int i = 0; i < count; i++)
        {
            slots[i].SetCardActive(cardTable.GetRandomCardData());
        }
        RefreshSlotElement();
    }

    //카드 정리
    public void RefreshSlotElement()
    {
        //카드정렬
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].HasChildrenObject() && i < slots.Length - 1)
            {
                int next = i + 1;
                if (slots[next].HasChildrenObject())
                {
                    //다음 카드를 내 자리로 위치 이동 시키고

                    slots[i].SetCardActive(slots[next].info.data);
                    
                    //카드를 원점으로

                    slots[next].info.gameObject.SetActive(false);
                }
            }
        }
    }

    //카드 추가
    public void AddedCardOnSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].HasChildrenObject()) continue;

            //한개씩 추가.
            slots[i].SetCardActive(cardTable.GetRandomCardData());
            break;
        }
    }

    //슬롯이 다 채워져 있는지 확인
    public bool CheckFilledSlot()
    {
        foreach (var slot in slots)
        {
            if (slot.HasChildrenObject() == false) return false;
        }
        return true;
    }
}
