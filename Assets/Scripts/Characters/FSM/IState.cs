public interface IState
{
    public void StateEnter();   //시작
    public void StateExecute(); //실행 (업데이트에 넣어야 함)
    public void StateExit();    //변동
}
