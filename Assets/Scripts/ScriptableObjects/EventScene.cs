using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EventScene", menuName = "ScriptableObject/EventScene")]
public class EventScene : Story         //이벤트신
{
    public List<Speaker> speakers;
    //완전히 다른 형태.
}
