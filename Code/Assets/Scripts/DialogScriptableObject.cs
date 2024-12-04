using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog/DialogData")]
public class DialogScriptableObject : ScriptableObject
{
    public DialogManager.DialogState[] dialogStates; // Array of dialog states
}
