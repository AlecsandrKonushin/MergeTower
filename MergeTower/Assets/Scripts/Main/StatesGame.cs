public class StatesGame : Singleton<StatesGame>
{
    public bool CanShoot { get; set; }

    public bool SetCanMove
    {
        set
        {
            UpdateController.instance.SetCanMove = value;
        }
    }
}
