using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Link Library", menuName = "SOs/Link Library")]
public class LinkLibrary : ScriptableObject
{
    [SerializeField]
    List<ImageLink> _library;

    public Sprite TryGettingSprite(string characterName)
    {
        Sprite s = null;

        foreach (ImageLink l in _library)
            if (l.CharacterName == characterName)
                s = l.CharacterImage;

        return s;
    }
}

