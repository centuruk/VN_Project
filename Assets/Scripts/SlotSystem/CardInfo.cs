using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfo : MonoBehaviour
{
    public CardData data;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI nameTaxt;
    //public Image iconImage;
    //need Seleted Image
    //need Tier Imag

    public void SetCardData(CardData data)
    {
        this.data = data;
        levelText.text = "Lv." + data.level.ToString();
        nameTaxt.text = data.name.ToString();
    }

    public bool CompareCardInfo(CardData data)
    {
        if (this.data.level == data.level && this.data.name == data.name) return true;
        else return false;
    }
    
    public void SetMergedData()
    {
        data.level++;
        levelText.text = "Lv." + data.level.ToString();
    }

    //레벨에 따른 보정 값을 정의해보기.
}
