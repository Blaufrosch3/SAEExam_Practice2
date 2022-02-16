[System.Serializable]
public class Dialogue
{
    public string CharacterName;
    public Interlocutor CurrentInterlocutor;
    [UnityEngine.Multiline(5)]
    public string Text;
}
