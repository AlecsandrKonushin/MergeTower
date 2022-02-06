using System.Collections.Generic;
using UnityEngine;

public class UIMain : Singleton<UIMain>
{
    public delegate void EndShow();
    public delegate void EndHide();
    public delegate void EndChange();

    public static event EndShow AfterEndShow;
    public static event EndHide AfterEndHide;
    public static event EndChange AfterEndChange;

    private Dictionary<TypePanel, Panel> panels = new Dictionary<TypePanel, Panel>();

    private static Panel prevPanel;
    private static Panel currentPanel;

    public static Panel GetPrevPanel { get => prevPanel; }
    public static Panel GetCurrentPanel { get => currentPanel; }

    private static bool canClick = true;
    public static bool GetCanClick { get => canClick; }

    public static void AddPanel(object obj)
    {
        var add = obj;
        var panel = obj as Panel;

        if (panel != null)
            Instance.panels.Add(panel.GetTypePanel, panel);
    }

    /// <summary>
    /// Действия(показать, скрыть, изменить) над панелью
    /// </summary>
    /// <param name="data"></param>
    public static void ActionUI(DataActionsUI data)
    {
        canClick = false;
        prevPanel = currentPanel;

        UIMain ui = Instance;
        currentPanel = null;
        ui.panels.TryGetValue(data.TypePanel, out currentPanel);

        if (currentPanel == null)
        {
            Debug.LogError("Нет панели   -  " + data.TypePanel);
        }

        if (data.TypeAction == TypeActionsUI.Show)
        {
            ui.ShowPanel(currentPanel);
        }
        else if (data.TypeAction == TypeActionsUI.Hide)
        {
            ui.HidePanel(currentPanel);
        }
        else if (data.TypeAction == TypeActionsUI.Change)
        {
            ui.ChangePanel(currentPanel);
        }
    }

    /// <summary>
    /// Показать какой-то UI, скрывая и изменяя всё, что ему мешает
    /// </summary>
    /// <param name="typeShow"></param>
    //public static void ShowUI(TypeUIShow typeShow)
    //{
    //    bool havePanel = false;

    //    foreach (var ui in uiShows)
    //    {
    //        if (ui.GetTypeUI == typeShow)
    //        {
    //            ui.ShowUI();
    //            havePanel = true;
    //            break;
    //        }
    //    }

    //    if (!havePanel)
    //    {
    //        Debug.LogError($"Не добавлена панель типа {typeShow} в UIMain.CreateUIShows");
    //    }
    //}

    private void ShowPanel(Panel panel)
    {
        panel.AfterEndShow += AfterShowPanel;
        panel.ShowPanel();
    }

    private void HidePanel(Panel panel)
    {
        panel.AfterEndHide += AfterHidePanel;
        panel.HidePanel();
    }
    private void ChangePanel(Panel panel)
    {
        panel.AfterEndChange += AfterChangePanel;
        panel.ChangePanel();
    }

    private void AfterShowPanel()
    {
        currentPanel.AfterEndShow -= AfterShowPanel;
        AfterEndShow?.Invoke();

        canClick = true;
    }
    private void AfterHidePanel()
    {
        currentPanel.AfterEndHide -= AfterHidePanel;
        AfterEndHide?.Invoke();

        canClick = true;
    }
    private void AfterChangePanel()
    {
        currentPanel.AfterEndChange -= AfterChangePanel;
        AfterEndChange?.Invoke();

        canClick = true;
    }
}
