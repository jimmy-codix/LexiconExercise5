namespace LexiconExercise5
{
    internal abstract class MenuItemBase
    {
        public int Key { get; private set; }
        public string Text { get; private set; }

        protected MenuItemBase(string text, int key)
        {
            Text = text;
            Key = key;
        }
    }
}