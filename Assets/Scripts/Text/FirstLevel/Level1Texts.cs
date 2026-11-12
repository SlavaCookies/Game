using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
public class Level1Texts : MonoBehaviour, IText
{
    public static Level1Texts Instance { get; private set; }
    private int _indexThoughtText = 0;
    private int _indexDialogText = 0;
    
    private List<string[]> _thoughtTexts = new List<string[]>() {
        new string[] { "А?...", "Где я?", "Что это впереди?"},
        new string[] { "Любое желание значит...", "Может так я смогу вернуться обратно." },
        new string[] { "Белые уши, торчащие из кустов, думаю я нашел его"},
        new string[] { "Может мне удасться его чем-то привлечь..."}
    };
    
    private List<string[]> _dialogTextsPlayer = new List<string[]>() { 
        new string[] { "Башня? Что это такое?", " ",
                       "Заплатить? Я даже не знаю, как тут оказался...", " ",
                       "...", "Как выглядит твой питомец?", " ",
                       "Необычный Заяц? Ладно."},
        new string[] { },
        new string[] { "Благодарю." }
    };
    private List<string[]> _dialogTextsNPC = new List<string[]>() { 
        new string[] { "Хм?", "Что тебе нужно? Тоже хочешь взобраться на башню?", " ",
                       "Башня, на которую могут взобраться лишь блистательные умы.",
                       "Взобравшись на башню ты сможешь исполнить любое желание.",
                       "Если хочешь испытать себя и войти в неё, то ты должен заплатить.", " ",
                       "... Ладно. Тебе повезло, я сегодня добрый, помоги мне найти моего питомца и" +
                       " я, так уж и быть, пропущу тебя.", "Сидит где-то он тут рядом.",
                       "Я бы и сам его поискал, но как видишь, я занят тем, чтобы стоять тут.",
                       "Как же я прекрасен. Правда?", " ",
                       "Питомец? Это Заяц, правда необычный, но это мне в нем и нравится. Ха-ха.", " "},
        new string[] { "Нашел?" }, 
        new string[] { "Как же хорошо, что ты нашел его, теперь я могу тебя пропустить, вперед.", " "}
    };
    private List<string> _whoStartTalk = new List<string>() { "npc", "npc", "npc" };
    public int IndexThought
    {
        get
        {
            return _indexThoughtText;
        }
        set
        {
            _indexThoughtText = value;
        }
    }

    public int IndexDialogText
    {
        get
        {
            return _indexDialogText;
        }
        set
        {
            _indexDialogText = value;
        }
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
