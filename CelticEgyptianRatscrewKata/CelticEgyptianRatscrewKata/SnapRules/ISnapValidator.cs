using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.SnapRules
{
    public interface ISnapValidator
    {
        bool CanSnap(IReadOnlyGameState gameState);
    }
}
