//Tutorial video: https://www.youtube.com/watch?v=Eg7oP7mcNbc

using UnityEngine;

public interface IInteractable
{
    public bool CanInteract();
    public bool Interact(PlayerInteractor interactor);
}
