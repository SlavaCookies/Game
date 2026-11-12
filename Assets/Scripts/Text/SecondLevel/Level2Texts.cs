using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Level2Texts : MonoBehaviour, IText
{
    public static Level2Texts Instance { get; private set; }
    private int _indexThoughtText = 0;
    private int _indexDialogText = 0;
    private List<string[]> _thoughtTexts = new List<string[]> {
        new string[] {"Лабиринт...",
        "Какое там было правило, всегда поворачивать налево?" },
        new string[] { "Видимо мне нужен ключ. Возможно он где-то рядом."},
        new string[] { "Ключ?" },
        new string[] { "Дверь открыта, можно на следующий этаж." }
    };
    private List<string[]> _dialogTextsPlayer = new List<string[]>() { };
    private List<string[]> _dialogTextsNPC = new List<string[]>() { };
    private List<string> _whoStartTalk = new List<string>() { };
    public int IndexThought
    {
        get { return _indexThoughtText; }
        set { _indexThoughtText = value; }
    }
    public int IndexDialogText
    {
        get { return _indexDialogText; }
        set { _indexDialogText = value; }
    }

    public List<string[]> ThoughtText
    {
        get { return _thoughtTexts; }
        set { _thoughtTexts = value; }
    }

    public List<string[]> DialogTextsPlayer
    {
        get { return _dialogTextsPlayer; }
        set { _dialogTextsPlayer = value; }
    }
    
    public List<string[]> DialogTextsNPC
    {
        get { return _dialogTextsNPC; }
        set { _dialogTextsNPC = value; }
    }

    public List<string> WhoStartTalk
    {
        get { return _whoStartTalk; }
        set { _whoStartTalk = value; }
    }
}
