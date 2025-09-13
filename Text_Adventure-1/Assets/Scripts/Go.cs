using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputAction/Go")]
public class Go : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        controller._roomNavigation.AttemptToChangeRooms(separatedInputWords[1]);
    }
}
