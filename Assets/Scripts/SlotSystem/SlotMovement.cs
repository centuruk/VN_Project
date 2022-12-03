using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//�ӽ� �巡�� �ص� ��� Ȯ��.
public class SlotMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //ó���� ���Կ� �������� ��ġ�ϰ� �ִٰ�.
    //���Կ� �巡�װ� �����ϸ� �и� �����ϰ� �̵� ����.
    //�̵��� ���ÿ� Ÿ���� �ϰ� ��ġ�� ����.
    //ȭ�� ���� �Ѿ�ų� ������ ���� ������ ���� �ڸ��� ���ư�.
    //�巡�װ� ���̳��ų� ����Ǹ� ���̾ƿ� ��������. (���ڸ� �޲ٱ�.) //�ڿ����� �̵��� �ʿ�������.

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�� ����");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 eventPos = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = eventPos;


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�� ��");
    }
}
