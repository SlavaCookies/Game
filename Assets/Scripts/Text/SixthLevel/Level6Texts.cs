using UnityEngine;
using System.Collections.Generic;

public class Level6Texts : MonoBehaviour, IText
{
    public static Level6Texts Instance { get; private set; }
    private int _indexThoughtText = 0;
    private int _indexDialogText = 0;
    private List<string[]> _thoughtTexts = new List<string[]>() { 
        new string[] { "Наконец-то я вернусь обратно..." }
    };
    private List<string[]> _dialogTextsPlayer = new List<string[]>() {
        new string[] { "Что это за этаж и какая тут головомка?", " "},
        new string[] { "Здесь будут задаваться ваши вопросы?", " ", "Сколько всего будет вопросов?", " "},
        new string[] { "Хочу вернуться обратно домой, туда, откуда я попал в это место.", " ", "Огромное спасибо!"}
    };
    private List<string[]> _dialogTextsNPC = new List<string[]>() { 
        new string[] {"Хм? Что такое, юноша?", " ", "Хо-хо, так вы за этим сюда пришли.", 
            "Хорошо, это этаж знаний, а я Великий Мудрец, хозяин этого этажа и всех остальных этажей тоже.", 
            "Я задам тебе несколько вопросов, если ты ответишь на них правильно, то я исполню любое твое желание.",
            "Пойдём к столу, там и пройдёт опрос." },
        new string[] { "Да, всё верно ты подметил. Ну что, начнём?", "Приготовься, вопросы могут быть не из простых.", " ", 
            "Вопросов у меня много, но ответить необхимо правильно всего на пять из них."}, 
        new string[] { "Поздравляю, ты правильно ответил на необходимое количество вопросов.", 
            "Слушаю твоё желание, юное дитя. Загадывай, не стесняйся.", " ", "Хо-хо, понял тебя.", 
            "Да будет исполнено твоё желание. Удачи тебе, юное дитя. Спасибо, что повеселил такого мудреца, как я.", " "}
    };
    private List<string> _whoStartTalk = new List<string>() { "npc", "player", "npc" };
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
