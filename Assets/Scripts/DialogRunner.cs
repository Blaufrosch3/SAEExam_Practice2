using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogRunner : MonoBehaviour
{
    [SerializeField] DialogDisplayer _dialogDisplayer;

    DialogueSequence _currentSequence;

    private void Start()
    {
        //StartCoroutine(DialogRoutineTest());
        //_dialogDisplayer.SetInterlocutor(Interlocutor.None);
        DialogueTest();
    }

    private void DialogueTest()
    {
        DialogueSequence script = new DialogueSequence();
        Dialogue current;

        //do scriptname elsewhere (as first dialogue)
        //script.SceneName = "TestScene";
        //_dialogDisplayer.SetInterlocutor(Interlocutor.None);
        //_dialogDisplayer.SetText(script.SceneName);

        current = new Dialogue();
        current.CharacterName = "";
        current.CurrentInterlocutor = Interlocutor.None;
        current.Text = "Joker takes a deep breath, pauses to see if it's over.";
        script.AddDialogue(current);

        current = new Dialogue();
        current.CharacterName = "";
        current.CurrentInterlocutor = Interlocutor.None;
        current.Text = "Beat.";
        script.AddDialogue(current);

        current = new Dialogue();
        current.CharacterName = "JOKER";
        current.CurrentInterlocutor = Interlocutor.Character1;
        current.Text = "is it just me, or is it getting crazier out there?";
        script.AddDialogue(current);

        current = new Dialogue();
        current.CharacterName = "";
        current.CurrentInterlocutor = Interlocutor.None;
        current.Text = "Despite the laughter, there's real pain in his eyes. Something broken in him.Looks like he hasn't slept in days.";
        script.AddDialogue(current);

        current = new Dialogue();
        current.CharacterName = "SOCIAL WORKER";
        current.CurrentInterlocutor = Interlocutor.Character2;
        current.Text = "It's certainly tense. People are upset, they're struggling. Looking for work.The garbage strike seems like it's been going on forever.These are tough times.";
        script.AddDialogue(current);

        current = new Dialogue();
        current.CharacterName = "";
        current.CurrentInterlocutor = Interlocutor.None;
        current.Text = "...";
        script.AddDialogue(current);

        _currentSequence = script;

        Debug.Log("D: " +_currentSequence.Dialogue.Count);

        DisplayNextDialogue();
    }

    private void DisplayNextDialogue()
    {
        if(_currentSequence != null && _currentSequence.Dialogue.Count > 0)
        {
            Dialogue c = _currentSequence.Dialogue.Dequeue();
            _dialogDisplayer.SetInterlocutor(c.CurrentInterlocutor);
            _dialogDisplayer.SetName(c.CharacterName);
            _dialogDisplayer.SetText(c.Text);

            Debug.Log("D ch: " + _currentSequence.Dialogue.Count);
        }
    }

    #region oldRoutine
    //private IEnumerator DialogRoutineTest()
    //{
    //    Debug.Log("Running Test");
    //    yield return new WaitForSeconds(1);
    //    dialogDisplayer.SetInterlocutor(Interlocutor.None);
    //    dialogDisplayer.SetText("Joker takes a deep breath, pauses to see if it's over.");

    //    yield return new WaitForSeconds(3);
    //    dialogDisplayer.SetText("Beat.");

    //    yield return new WaitForSeconds(2);
    //    dialogDisplayer.SetInterlocutor(Interlocutor.Character1);
    //    dialogDisplayer.SetName("JOKER");
    //    dialogDisplayer.SetText("is it just me, or is it getting crazier out there?");

    //    yield return new WaitForSeconds(4);
    //    dialogDisplayer.SetInterlocutor(Interlocutor.None);
    //    dialogDisplayer.SetText("Despite the laughter, there's real pain in his eyes. Something broken in him.Looks like he hasn't slept in days.");

    //    yield return new WaitForSeconds(5);

    //    dialogDisplayer.SetInterlocutor(Interlocutor.Character2);
    //    dialogDisplayer.SetName("SOCIAL WORKER");
    //    dialogDisplayer.SetText("It's certainly tense. People are upset, they're struggling. Looking for work.The garbage strike seems like it's been going on forever.These are tough times.");

    //    yield return new WaitForSeconds(10);
    //    dialogDisplayer.SetInterlocutor(Interlocutor.None);
    //    dialogDisplayer.SetText("");
    //}
    #endregion

    public void ContinueDialogue()
    {
        Debug.Log("Continue pressed");
        DisplayNextDialogue();
    }
}