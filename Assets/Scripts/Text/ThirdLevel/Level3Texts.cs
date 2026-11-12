using UnityEngine;
using System.Collections.Generic;

public class Level3Texts : MonoBehaviour, IText
{
    public static Level3Texts Instance { get; private set; }
    private int _indexThoughtText = 0;
    private int _indexDialogText = 0;
    private List<string[]> _thoughtTexts = new List<string[]>() {
        new string[] { "Значит надо собрать картину...", "Думаю, лучше стоит осмотреться для начала" },
        new string[] { "Какая интересная Лягушка здесь оказалась.", "И требовательная к тому же..."},
        new string[] { "Возможно это какой-то пароль." },
        new string[] { "А вот и ключ." }
    };
    private List<string[]> _dialogTextsPlayer = new List<string[]>() { 
        new string[] {"Что?", " ", "Говорящая лянушка... я видел все.", " ", 
            "Мне нужна эта часть картины, чтобы собрать ее полностью.", " ", "Если я найду картину лучше?", 
            " "},
        new string[] { "Вот картина лучше, как и говорил.", " ", "Спасибо за эту часть картины." }
    };
    private List<string[]> _dialogTextsNPC = new List<string[]>() { 
        new string[] { "Эй! Куда руки тянешь! Мое! Ква.", " ", "Всмысле Что? Ква, это моя картина, ква.",
        "Ходят тут всякие непонятные, ква, так и хотят взять мою картину крутую, ква", " ", 
        "Да, ква, говорящая, ква, и что, ква, ты не знал о нас, ква? Теперь знаешь, ха-ха, ква.", 
        "В любом случае я картину тебе не отдам, ква.", " ", "И что? Ква, мне тоже эта часть картины нужна, любоваться ею, ква",
        " ", "Картину лучше, ква? Что-то еще прекраснее, ква?...", "...", 
            "Если картина, которую ты мне принесешь, окажется очаровательнее, ква, то как и быть, я отдам тебе эту часть картины, ква.",
            "Но если, ква, эта картина не окажется лучше, то я не отдам тебе часть часть картины, ква." },
        new string[] { "Хм, ква. Это же шедевральная картина! Ква! Я обменяю на эту картину то, что тебе нужно, ква, забирай, ква.",
        "Давай же, выполним обмен, ква", " ", "Тебе спасибо, ква, за такой шедевр, ква.", "Буду теперь любоваться картиной, ква."}
    };
    private List<string> _whoStartTalk = new List<string>() { "npc", "player" };
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
