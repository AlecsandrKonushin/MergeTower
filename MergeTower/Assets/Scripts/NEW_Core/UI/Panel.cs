using System.Collections;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public delegate void EndShow();
    public delegate void EndHide();
    public delegate void EndChange();

    public event EndShow AfterEndShow;
    public event EndHide AfterEndHide;
    public event EndHide AfterEndChange;

    [SerializeField] protected GameObject background;

    protected float timeShow;
    protected float timeHide;
    protected float timeChange = 0;

    [SerializeField] protected TypePanel typePanel;
    public TypePanel GetTypePanel { get => typePanel; }

    private void Start()
    {
        UIMain.AddPanel(this);

        SetAnimationTime();
    }

    private void SetAnimationTime()
    {
        AnimationClip[] animations = background.GetComponent<Animator>().runtimeAnimatorController.animationClips;

        foreach (var anim in animations)
        {
            if (anim.name == TypeAnimationUI.Show.ToString())
                timeShow = anim.length;
            if (anim.name == TypeAnimationUI.Hide.ToString())
                timeHide = anim.length;
            if (anim.name == TypeAnimationUI.Change.ToString())
                timeChange = anim.length;
        }
    }

    public void ShowPanel()
    {
        background.SetActive(true);
        StartCoroutine(CoEndShowPanel());

        ShowDataPanel();
    }

    protected virtual void ShowDataPanel() { }

    private IEnumerator CoEndShowPanel()
    {
        yield return new WaitForSeconds(timeShow);
        AfterEndShow?.Invoke();
    }

    public void HidePanel()
    {
        background.GetComponent<Animator>().SetTrigger(TypeAnimationUI.Hide.ToString());
        StartCoroutine(CoEndHidePanel());
    }

    protected virtual void HideDataPanel() { }

    protected virtual void BeforeHidePanel() { }

    protected virtual void AfterHidePanel() { }

    private IEnumerator CoEndHidePanel()
    {
        BeforeHidePanel();
        yield return new WaitForSeconds(timeHide);
        HideDataPanel();
        background.SetActive(false);
        AfterHidePanel();
        AfterEndHide?.Invoke();
    }

    public void ChangePanel()
    {
        background.GetComponent<Animator>().SetTrigger(TypeAnimationUI.Change.ToString());
        StartCoroutine(CoEndChangePanel());

        ChangeDataPanel();
    }

    protected virtual void ChangeDataPanel() { }

    private IEnumerator CoEndChangePanel()
    {
        yield return new WaitForSeconds(timeChange);
        AfterEndChange?.Invoke();
    }
}

