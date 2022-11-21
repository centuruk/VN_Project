using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation", menuName = "ScriptableObject/Conversation")]
public class ConversationScene : Story  //�Ϲݴ�ȭ
{
    //��ȭ�� ���� ��忡 ���� ��� ��ȭ�� �ʿ���.
    public List<Sentence> speakers;
    public Sprite BackGround;
    public Story nextScene;

    [System.Serializable]
    public class Sentence
    {
        public Speaker speaker;
        [Header("����")]
        public Sentiment sentiment = Sentiment.NORAML;
        [Header("���"), TextArea]
        public string sentence;
    }
}

public class Story : ScriptableObject { }
