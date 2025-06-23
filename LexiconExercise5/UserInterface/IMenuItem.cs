
using LexiconExercise5.Interfaces;

namespace LexiconExercise5.UserInterface
{
    internal interface IMenuItem : IMenuItemBase
    {
        Action Caller { get; }
    }
}