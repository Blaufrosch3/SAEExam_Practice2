using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class TextToSequenceConverter
{
    public static DialogueSequence ConvertFromText(string text)
    {
        if (text == null || text.Length == 0 || string.IsNullOrWhiteSpace(text))
        {
            Debug.LogError("Text is NULL");
            return null;
        }

        DialogueSequence seq = new DialogueSequence();
        Dialogue current;
        string char1, char2;

        //SPLIT TEXT 
        List<string> segments = text.Split(new string[] { "<b>" }, System.StringSplitOptions.None).ToList();
        //first segment is empty (whyever)
        segments.RemoveAt(0);


        //----------SCENE NAME AND DESCRIPTION---------------
        //First segment is <b>sceneName + </b>description
        string[] segmentSplit = segments[0].Split(new string[] { "</b>" }, System.StringSplitOptions.None);
        //Debug
        //for (int i = 0; i < sceneStart.Length; i++)
        //    Debug.Log(i + "|:" + sceneStart[i]);

        //SCENE NAME
        current = new Dialogue();
        current.CurrentInterlocutor = Interlocutor.None;
        current.Text = segmentSplit[0].Replace("  ", "");
        seq.AddDialogue(current);
        //SCENE DESCRIPTION
        current = new Dialogue();
        current.CurrentInterlocutor = Interlocutor.None;
        current.Text = segmentSplit[1].Replace("  ", "");
        seq.AddDialogue(current);

        segments.RemoveAt(0);


        //-------------INDIVIDUAL-----------------------
        for(int i = 0; i < segments.Count; i++)
        {
            //Debug.Log(i + "|:" + segments[i]);
            current = new Dialogue();

            segmentSplit = segments[i].Split(new string[] { "</b>" }, System.StringSplitOptions.None);
            Debug.Log("["+i+"]NAME:_" + segmentSplit[0]);
            Debug.Log("[" + i + "]TEXT:_" + segmentSplit[1]);


            ////Name
            //if (string.IsNullOrWhiteSpace(segmentSplit[0]))
            //    current.CurrentInterlocutor = Interlocutor.None;
            //else
            //{
            //    Debug.Log("[" + i + "]CHARACTER");
            //    //CHECK FOR NAME -> IS NAME char1/char2

            //}
            ////Text
            //current.Text = segmentSplit[1].Replace("  ", "");
            current.CharacterName = segmentSplit[0];
            current.CurrentInterlocutor = Interlocutor.Character1;
            current.Text = segmentSplit[1];
            seq.AddDialogue(current);
        }


        return seq;
    }
}
