using System.Collections.Generic;
using UnityEngine;

public class Figures : MonoBehaviour
{
    public static Figures Instance { get; private set; }
    [SerializeField] private Figure whitePawn;
    [SerializeField] private Figure blackPawn;
    [SerializeField] private Figure whiteOfficer;
    [SerializeField] private Figure blackOfficer;
    [SerializeField] private Figure whiteRook;
    [SerializeField] private Figure blackRook;
    [SerializeField] private Figure whiteHorse;
    [SerializeField] private Figure blackHorse;
    [SerializeField] private Figure whiteKing;
    [SerializeField] private Figure blackKing;
    [SerializeField] private Figure whiteQueen;
    [SerializeField] private Figure blackQueen;
    [SerializeField] private GameObject objectStep;
    private Dictionary<string, Figure> _figures = new Dictionary<string, Figure>();
    public Dictionary<string, Figure> FiguresLevel
    {
        get { return _figures; }
        set { _figures = value; }


    }
    public GameObject StepObject
    {
        get { return objectStep; }
        set { objectStep = value; }
    }
    private void Awake()
    {
        Instance = this;
        _figures = new Dictionary<string, Figure>
        {
            { FiguresSO.nicknameWhitePawn, whitePawn },
            { FiguresSO.nicknameBlackPawn, blackPawn },
            { FiguresSO.nicknameWhiteOfficer, whiteOfficer },
            { FiguresSO.nicknameBlackOfficer, blackOfficer },
            { FiguresSO.nicknameWhiteRook, whiteRook },
            { FiguresSO.nicknameBlackRook, blackRook },
            { FiguresSO.nicknameWhiteHorse, whiteHorse },
            { FiguresSO.nicknameBlackHorse, blackHorse },
            { FiguresSO.nicknameWhiteKing, whiteKing },
            { FiguresSO.nicknameBlackKing, blackKing },
            { FiguresSO.nicknameWhiteQueen, whiteQueen },
            { FiguresSO.nicknameBlackQueen, blackQueen }
        };
    }
}
