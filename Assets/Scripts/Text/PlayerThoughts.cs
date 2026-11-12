using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerThoughts : MonoBehaviour
{
    public static PlayerThoughts Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public string[] StartLevelPlayerThoughts()
    {
        string[] thoughts = { "И зачем я только согласился на этот спор...",
                              "Не пришлось бы сюда идти."};
        return thoughts;
    }
   

    public string[] StartLevelPlayerThoughtsBox()
    {
        string[] thoughts = { "Что это? Коробка? По среди дороги?",
                              "Думаю лучше отодвинуть коробку в сторону."};
        return thoughts;
    }
    




}
