using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//임시 드래그 앤드 드롭 확인.
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

        //슬롯 크기 고정시키기.
        ResetRectPosition();

        slotManager = FindObjectOfType<SlotManager>();
        slot = GetComponentInParent<CardSlot>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(canvas);
        MovementPosition(eventData);
        transform.SetAsLastSibling(); //가장 마지막에 렌더링

        cardImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        MovementPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //충돌 여부 확인하기
        List<RaycastResult> result = new List<RaycastResult>();
        raycaster.Raycast(eventData, result);
        foreach (RaycastResult r in result)
        {
            if (!r.gameObject.CompareTag("Merge")) continue;

            //같은 조건의 카드를 만났을때
            target = r.gameObject.GetComponent<Slot>();
            if(target is CardSlot)
            {
                CardSlot targetSlot = target as CardSlot;
                //데이터 내용이 같고 타겟과 같은 오브젝트가 아니라면.
                if (slot.info.CompareCardInfo(targetSlot.info.data) && previousParent != target.transform)
                {
                    targetSlot.SetCardDrop(slot.info.data);
                    gameObject.SetActive(false);
                }
            }
            else if(target is GameSlot)
            {
                GameSlot targetSlot = target as GameSlot;
                targetSlot.SetCardDrop(slot.info.data); //이거 추상클래스 변경 해보기.
                gameObject.SetActive(false);
            }

            //슬롯 매니져 카드 정렬
            slotManager.RefreshSlotElement();
        }

        cardImage.raycastTarget = true;
        ResetRectPosition();
    }

    //커서 위치 따라가기.
    public void MovementPosition(PointerEventData eventData)
    {
        Vector2 eventPos = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = eventPos;
    }


    public void ResetRectPosition()
    {
        transform.SetParent(previousParent);

        //슬롯 크기 고정시키기.
        rect.localScale = Vector3.one;
        rect.anchoredPosition3D = Vector3.zero;
    }
}
