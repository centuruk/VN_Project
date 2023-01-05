using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public string name;

    //체력
    //공격력 //마력과 비슷
    //치명타확률
    //치명타데미지
    //스킬 포인트 (스킬 사용가능 횟수)
    //민첩 : 회피율 //명중률 
    //민첩 수치를 이용하여 캐릭터 이동 속도.

    //공격속도 : 기본값 1 
}

public class PlayerableStat : Stats
{
    public uint level; //0부터 시작
    
    //경험치 값을 하나로 해야하나?
}

public class MonsterStat : Stats
{
    public TargetSelectType type;
}