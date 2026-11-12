using System.Collections.Generic;
using UnityEngine;

public class Level5texts : MonoBehaviour, IText
{
    public static Level5texts Instance { get; private set; }
    private int _indexThoughtText = 0;
    private int _indexDialogText = 0;
    private List<string[]> _thoughtTexts = new List<string[]>() {
        new string[] { "Действительно энергичнее...", "Интересно, сколько ещё этажей мне нужно будет пройти...",
        "Почти уверен, что танец, это определённая головоломка.",
        "Какое большое поле тут находится...",
        "Думаю, тетрадка и ручка не помешали бы."},
        new string[] { "Ещё пять раз..." },
        new string[] { "После всех танцев до этого, думаю, всё же, не будет так сложно, наверное."}

    };
    private List<string[]> _dialogTextsPlayer = new List<string[]>() { 
        new string[] { "Что?", "Кто ты и кто вы? Не понимаю, какой ещё танец?",
        "Что на прошлом уровне, что на этом, одни загадки какие-то...", " "},
        new string[] { "Я прошёл, теперь я могу пройти дальше?", " ", "..." },
        new string[] { },
        new string[] { },
        new string[] { "Вроде прошёл...", " ", "Интересно, что там будет дальше..."}
    };
    private List<string[]> _dialogTextsNPC = new List<string[]>() {
        new string[] { "Воу-воу-воу, глядите, это же наша новая звезда танцпола!",
        "Поаплодируем же ему!", "Я, как и все мы, хотим лицезреть ваш сногшибательный танец!",
        "Давайте же! Вперёд!", "Я верю, что покажете высший танец!", " ", "Наша звезда в смятении! Мы понимаем это.", 
        "Тогда, для того, чтобы наша звезда сияла, отвечу на пару вопросов.", "Я ведущий этого этажа, который просто обожает танцы!",
        "Что на четвёртом этаже... Там тоже ведущий, но я ещё лучше, чем он! Я ещё более энергичный!", "А теперь вам время танцевать!", 
        "Покажите нам силу ваших танцев!", "Аплодисменты!"}, 
        new string[] { "Ха-ха, вы правда оправдываете наши ожидания! Осталось ещё 9 танцев!", " "},
        new string[] { "Зрители, в том числе и я, в восторге от вас!", "Пара следующих танцев будут простыми!"},
        new string[] { "Как же интересно за вами наблюдать!", "Приготовьтесь, следующий танец будет немного сложным!"},
        new string[] { "Вы прошли все танцы, так держать!", "Рядом должен быть ключ где-то, с помощью него, вы сможете попасть на следующий, последний этаж!"}
    };
    private List<string> _whoStartTalk = new List<string>() { "npc", "player", "npc", "npc", "player"};
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
