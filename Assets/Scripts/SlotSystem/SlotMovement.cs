using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//임시 드래그 앤드 드롭 확인.
public class SlotMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //처음에 슬롯에 차곡차곡 위치하고 있다가.
    //슬롯에 드래그가 시작하면 분모를 변경하고 이동 시작.
    //이동과 동시에 타게팅 하고 겹치기 시전.
    //화면 밖을 넘어가거나 조건이 맞지 않으면 원래 자리로 돌아감.
    //드래그가 끝이나거나 실행되면 레이아웃 리프레시. (빈자리 메꾸기.) //자연스런 이동이 필요할지도.

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("드래그 시작");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 eventPos = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = eventPos;


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("드래그 끝");
    }
}
