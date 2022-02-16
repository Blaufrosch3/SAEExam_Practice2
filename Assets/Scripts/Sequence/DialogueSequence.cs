using System.Collections.Generic;

[System.Serializable]
public class DialogueSequence
{
    public string SceneName;
    public Queue<Dialogue> Dialogue = new Queue<Dialogue>();

    public void AddDialogue(Dialogue d)
    {
        Dialogue.Enqueue(d);
    }
}
