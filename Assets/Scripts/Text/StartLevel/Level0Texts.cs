using UnityEngine;
using System.Collections.Generic;

public class Level0Texts : MonoBehaviour, IText
{
    public static Level0Texts Instance { get; private set; }
    private int _indexThoughtText = 0;
    private int _indexDialogText = 0;
    private List<string[]> _thoughtTexts = new List<string[]>() { 
        new string[] { "И зачем я только согласился на этот спор...", 
            "Не пришлось бы сюда идти." },
        new string[] { "Что это? Коробка? По среди дороги?", 
            "Думаю лучше отодвинуть коробку в сторону." },
        new string[] { "Этот портал...", "Наконец-то я вернулся.", 
            "Необычное было приключение...", "Надо выбираться отсюда, в ту сторону, с которой я пришёл сюда.", 
            "А коробка все ещё на том месте, куда я передвинул эту коробку..." }
        
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
