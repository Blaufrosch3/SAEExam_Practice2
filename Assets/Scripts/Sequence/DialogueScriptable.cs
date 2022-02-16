using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "SOs/Dialogue")]
public class DialogueScriptable : ScriptableObject
{
    [SerializeField]
    DialogueSequence _script;

    [SerializeField]
    System.Collections.Generic.List<Dialogue> _dialogue;


    public DialogueSequence GetMyScript
    {
        get
        {
            OnValidate();
            return _script;
        }
    }

    private void OnValidate()
    {
        _script.Dialogue.Clear();

        //Starting Scene
        Dialogue start = new Dialogue();
        start.CharacterName = "";
        start.CurrentInterlocutor = Interlocutor.None;
        start.Text = _script.SceneName;
        _script.AddDialogue(start);

        foreach (Dialogue d in _dialogue)
            _script.AddDialogue(d);
    }
}
