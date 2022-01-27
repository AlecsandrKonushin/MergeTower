public class StatesGame : Singleton<StatesGame>
{
    public bool SetCanMove
    {
        set
        {
            UpdateController.instance.SetCanMove = value;
        }
    }

}
