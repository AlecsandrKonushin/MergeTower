namespace UI
{
    public interface IUIElement
    {
        bool IsActive { get; }

        void Show();
        void Change();
        void Hide();
    }
}
