using UnityEngine;

[CreateAssetMenu(fileName = "InputActions", menuName = "Scriptable Objects/InputActions")]
public abstract class InputAction : ScriptableObject
{
    public string keyWord;
    public abstract void RespondToInput(GameController controller, string[] separatedInputWords);
}
