public interface IState
{
    public void StateEnter();   //����
    public void StateExecute(); //���� (������Ʈ�� �־�� ��)
    public void StateExit();    //����
}
