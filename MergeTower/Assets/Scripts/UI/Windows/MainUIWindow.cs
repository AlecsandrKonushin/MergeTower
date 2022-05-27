using UnityEngine;

namespace UI
{
    public class MainUIWindow : UIWindow
    {
        [SerializeField] private BuyTowerButton buyTowerButton;

        protected override void AfterInitialization()
        {
            buyTowerButton.OnInitialize();
            buyTowerButton.OnStart();
        }
    }
}