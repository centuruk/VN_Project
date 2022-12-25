using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//�ӽ� �巡�� �ص� ��� Ȯ��.
public class SlotMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Transform canvas;
    [SerializeField] Transform previousParent;
    [SerializeField] GraphicRaycaster raycaster;   
    
    [SerializeField] RectTransform rect;
    [SerializeField] Image cardImage;

    private SlotManager slotManager;
    private CardSlot slot;

    private Slot target;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        raycaster = FindObjectOfType<GraphicRaycaster>();
        rect = GetComponent<RectTransform>();
        cardImage = GetComponent<Image>();

        //���� ũ�� ������Ű��.
        ResetRectPosition();

        slotManager = FindObjectOfType<SlotManager>();
        slot = GetComponentInParent<CardSlot>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(canvas);
        MovementPosition(eventData);
        transform.SetAsLastSibling(); //���� �������� ������

        cardImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        MovementPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //�浹 ���� Ȯ���ϱ�
        List<RaycastResult> result = new List<RaycastResult>();
        raycaster.Raycast(eventData, result);
        foreach (RaycastResult r in result)
        {
            if (!r.gameObject.CompareTag("Merge")) continue;

            //���� ������ ī�带 ��������
            target = r.gameObject.GetComponent<Slot>();
            if(target is CardSlot)
            {
                CardSlot targetSlot = target as CardSlot;
                //������ ������ ���� Ÿ�ٰ� ���� ������Ʈ�� �ƴ϶��.
                if (slot.info.CompareCardInfo(targetSlot.info.data) && previousParent != target.transform)
                {
                    targetSlot.SetCardDrop(slot.info.data);
                    gameObject.SetActive(false);
                }
            }
            else if(target is GameSlot)
            {
                GameSlot targetSlot = target as GameSlot;
                targetSlot.SetCardDrop(slot.info.data); //�̰� �߻�Ŭ���� ���� �غ���.
                gameObject.SetActive(false);
            }

            //���� �Ŵ��� ī�� ����
            slotManager.RefreshSlotElement();
        }

        cardImage.raycastTarget = true;
        ResetRectPosition();
    }

    //Ŀ�� ��ġ ���󰡱�.
    public void MovementPosition(PointerEventData eventData)
    {
        Vector2 eventPos = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = eventPos;
    }


    public void ResetRectPosition()
    {
        transform.SetParent(previousParent);

        //���� ũ�� ������Ű��.
        rect.localScale = Vector3.one;
        rect.anchoredPosition3D = Vector3.zero;
    }
}
