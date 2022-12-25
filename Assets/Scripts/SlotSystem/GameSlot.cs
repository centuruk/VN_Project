using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameSlot : Slot, IPointerEnterHandler, IPointerExitHandler
{
    private Color previousColor;
    public Color pointerColor;
    public Color dropColor;
    public Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        previousColor = image.color;    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;
        if (eventData.pointerDrag.GetComponent<CardInfo>())
        {
            image.color = pointerColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = previousColor;
    }

    //드랍했을때.
    public override void SetCardDrop(CardData data)
    {
        StartCoroutine(ReturnColorProcess());
    }

    IEnumerator ReturnColorProcess()
    {
        image.color = dropColor;
        yield return new WaitForSeconds(0.2f);
        image.color = previousColor;
    }
}
