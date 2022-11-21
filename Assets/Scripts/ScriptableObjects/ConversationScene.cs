using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation", menuName = "ScriptableObject/Conversation")]
public class ConversationScene : Story  //일반대화
{
    //대화중 관찰 모드에 따른 대기 대화가 필요함.
    public List<Sentence> speakers;
    public Sprite BackGround;
    public Story nextScene;

    [System.Serializable]
    public class Sentence
    {
        public Speaker speaker;
        [Header("감정")]
        public Sentiment sentiment = Sentiment.NORAML;
        [Header("대사"), TextArea]
        public string sentence;
    }
}

public class Story : ScriptableObject { }
