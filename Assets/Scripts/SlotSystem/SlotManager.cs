using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [SerializeField] CardSlot[] slots;
    [Header("ī�� ������ ���̺�")]
    public CardTableData cardTable;
    
    //�������� ���� ���μ��̿��� ī�带 ȣ���ϴ� ���� ���⼭ �������.
    [Header("�ӽ�"), Range(1, 13)]
    public int count = 0;

    private void Start()
    {

        for (int i = 0; i < count; i++)
        {
            slots[i].SetCardActive(cardTable.GetRandomCardData());
        }
        RefreshSlotElement();
    }

    //ī�� ����
    public void RefreshSlotElement()
    {
        //ī������
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].HasChildrenObject() && i < slots.Length - 1)
            {
                int next = i + 1;
                if (slots[next].HasChildrenObject())
                {
                    //���� ī�带 �� �ڸ��� ��ġ �̵� ��Ű��

                    slots[i].SetCardActive(slots[next].info.data);
                    
                    //ī�带 ��������

                    slots[next].info.gameObject.SetActive(false);
                }
            }
        }
    }

    //ī�� �߰�
    public void AddedCardOnSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].HasChildrenObject()) continue;

            //�Ѱ��� �߰�.
            slots[i].SetCardActive(cardTable.GetRandomCardData());
            break;
        }
    }

    //������ �� ä���� �ִ��� Ȯ��
    public bool CheckFilledSlot()
    {
        foreach (var slot in slots)
        {
            if (slot.HasChildrenObject() == false) return false;
        }
        return true;
    }
}
