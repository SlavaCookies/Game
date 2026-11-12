using UnityEngine;
using System.Collections.Generic;
using System.Net.Http.Headers;

public class Level4Texts : MonoBehaviour, IText
{
    public static Level4Texts Instance { get; private set; }
    private int _indexThoughtText = 0;
    private int _indexDialogText = 0;
    private List<string[]> _thoughtTexts = new List<string[]>() { 
        new string[] { 
            "Ощущение, что чего-то недостаёт..." 
        } 
    };
    private List<string[]> _dialogTextsPlayer = new List<string[]>() { 
        new string[] { },
        new string[] { },
        new string[] { },
        new string[] { },
        new string[] { },
        new string[] { },
        new string[] { },
        new string[] { },
        new string[] { },
        new string[] { }
    };
    private List<string[]> _dialogTextsNPC = new List<string[]>() {
        new string[] { "Кхм-кхм, как слышно?", "Связь, кажется, в норме, отлично.",
            "Великий путешественник! Как рад, что ты здесь.", "И для того, чтобы продолжить путь дальше, тебе нужно решить несколько задач.",
            "Тебе нужно сделать один ход в Шахматах, чтобы у противника был шах и мат.",
            "Если сделанный вами ход не делал шах и мат противнику, то текущая задача начинается заново, если шах и мат есть, то появляется следующая задача."
        },
        new string[] { "Совершенно верно!" },
        new string[] { "Вам всё по плечу, я сразу заметил это."},
        new string[] { "Весьма... Гениально!"},
        new string[] { "И эта задача решена вами."},
        new string[] { "Эта задача тоже решена вами."},
        new string[] { "Отлично сделано."},
        new string[] { "Этот ход был хорош."},
        new string[] { "Вы и это смогли решить."},
        new string[] { ".....", "Превосходно! Поздравляю! Вы смогли решить такую непростую задачу и это весьма похвально.",
            "Я даю возможность пройти дальше.", "Где-то рядом должен быть ключ от двери этого этажа."
        }
    };
    private List<string> _whoStartTalk = new List<string>() { "npc", "npc", "npc", "npc", "npc", 
    "npc", "npc", "npc", "npc", "npc"};
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
    private void Awake()
    {
        Instance = this;
    }
}
