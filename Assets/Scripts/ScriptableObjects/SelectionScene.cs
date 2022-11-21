using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectionScene", menuName = "ScriptableObject/SelectionScene")]
public class SelectionScene : Story
{
    //������ ���丮
    public List<Selection> selections;
    public Sprite BackGround; //������ ��濡�� ���� �״�� ��ȯ�� �Ǵ�??

    [System.Serializable]
    public struct Selection
    {
        public string description;
        public Story selectedStory;
    }
}
