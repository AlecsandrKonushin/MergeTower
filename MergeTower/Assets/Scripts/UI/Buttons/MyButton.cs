using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class MyButton : UIElement
    {
        protected override void AfterInitialization()
        {
            GetComponent<Button>().onClick.AddListener(OnClickButton);
        }

        private void OnClickButton()
        {
            OtherActionClick();
        }

        protected virtual void OtherActionClick()
        {

        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClickButton);
        }
    }
}