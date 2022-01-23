using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonMy : MonoBehaviour
{
    //[SerializeField] protected TypeUISound soundClick = TypeUISound.ButtonClick;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickByButton);
    }

    private void ClickByButton()
    {
        //if (UIMain.GetCanClick)
        //{
            //ControllerAudio.Instance.PlayUISound(soundClick);
            OtherButtonAction();
        //}
        //else
        //{
        //    return;
        //}
    }

    protected virtual void OtherButtonAction()
    {

    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(ClickByButton);
    }
}
