public class DataActionsUI 
{
    public TypeActionsUI TypeAction;
    public TypePanel TypePanel;

    public DataActionsUI(TypeActionsUI typeAction, TypePanel typePanel)
    {
        TypeAction = typeAction;
        TypePanel = typePanel;
    }
}

public enum TypeActionsUI
{
    Show, 
    Hide,
    Change
}
