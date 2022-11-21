using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speaker", menuName = "ScriptableObject/Speakers")]
[System.Serializable]
public class Speaker : ScriptableObject
{
    public string speaker = "";
}
