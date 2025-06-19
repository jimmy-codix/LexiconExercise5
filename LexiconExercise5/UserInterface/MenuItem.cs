namespace LexiconExercise5.UserInterface
{
    internal class MenuItem : MenuItemBase
    {
        public Action Caller { get; private set; }

        public MenuItem(string text, int key, Action caller) : base(text,key)
        {
            Caller = caller;
        }

    }
}