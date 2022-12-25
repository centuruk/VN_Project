using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Slot : MonoBehaviour
{
    public abstract void SetCardDrop(CardData data);
}
