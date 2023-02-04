namespace Runtime.Actor.InteractActions
{
    public interface IInteractionAction
    {
        InteractionType Type { get; }
        void DoInteraction();
    }
}