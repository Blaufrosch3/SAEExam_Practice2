using System.Collections.Generic;

[System.Serializable]
public class DialogueSequence
{
    public string SceneName;
    public Queue<Dialogue> Dialogue = new Queue<Dialogue>();

    public string GetCharacter1Name
    {
        get
        {
            foreach (Dialogue d in Dialogue)
                if (d.CurrentInterlocutor == Interlocutor.Character1)
                    return d.CharacterName;

            return "NO CHAR1 NAME";
        }
    }
    public string GetCharacter2Name
    {
        get
        {
            foreach (Dialogue d in Dialogue)
                if (d.CurrentInterlocutor == Interlocutor.Character2)
                    return d.CharacterName;

            return "NO CHAR2 NAME";
        }
    }

    public void AddDialogue(Dialogue d)
    {
        Dialogue.Enqueue(d);
    }
}
