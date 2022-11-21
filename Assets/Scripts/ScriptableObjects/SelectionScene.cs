using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectionScene", menuName = "ScriptableObject/SelectionScene")]
public class SelectionScene : Story
{
    //선택지 스토리
    public List<Selection> selections;
    public Sprite BackGround; //기존의 배경에서 뭔가 그대로 변환이 되는??

    [System.Serializable]
    public struct Selection
    {
        public string description;
        public Story selectedStory;
    }
}
