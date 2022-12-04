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

    [SerializeField] Transform canvas;
    [SerializeField] GraphicRaycaster raycaster;   
    [SerializeField] Transform previousParent;
    [SerializeField] RectTransform rect;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        raycaster = FindObjectOfType<GraphicRaycaster>();
        rect = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�� ����");
        previousParent = transform.parent;
        transform.SetParent(canvas);
        transform.SetAsLastSibling(); //���� �������� ������
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 eventPos = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = eventPos;

        //�浹 ���� Ȯ���ϱ�
        List<RaycastResult> result = new List<RaycastResult>();
        raycaster.Raycast(eventData, result);
        foreach(RaycastResult r in result)
        {
            Debug.Log(r.gameObject.name);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�� ��");
    }
}