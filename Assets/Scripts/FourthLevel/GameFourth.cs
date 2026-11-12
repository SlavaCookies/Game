using System.Collections.Generic;
using UnityEngine;

public class GameFourth : MonoBehaviour
{
    public static GameFourth Instance { get; private set; }
    [SerializeField] private Transform deskTransform;
    [SerializeField] private Key key;
    [SerializeField] private Vector3 keyPosition;
    private string[][] _figuresDesk = new string[8][];
    private List<Figure> _figures = new List<Figure>();
    private int _numberLevel = 0;
    private Vector2 _positionsFiguresOnDesk = new Vector2(6, 26);
    public string[][] FiguresDesk
    {
        get { return _figuresDesk; }
        set { _figuresDesk = value; }
    }
    public Vector2 PositionsFiguresOnDesk
    {
        get { return _positionsFiguresOnDesk; }
        set { _positionsFiguresOnDesk = value; }
    }
    public List<Figure> ObjectsFigures
    {
        get { return _figures; }
        set { _figures = value; }
    }
    
    public List<Figure> figures
    {
        get { return _figures; }
        set { _figures = value; }
    }
    public int NumberLevel
    {
        get { return _numberLevel; }
        set { _numberLevel = value; }
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        switch (_numberLevel)
        {
            case 0:
                _figuresDesk = new string[8][]{
                new string[8] { " ", " ", " ", " ", " ", " ", " ", "bo" },
                new string[8] { " ", " ", " ", " ", " ", " ", " ", " " },
                new string[8] { "wr", " ", " ", " ", " ", " ", " ", " " },
                new string[8] { " ", " ", " ", " ", "wo", "bk", " ", " " },
                new string[8] { " ", " ", "wh", " ", " ", " ", " ", " " },
                new string[8] { " ", " ", " ", " ", "wp", " ", " ", "br" },
                new string[8] { "bp", " ", " ", " ", " ", " ", " ", " " },
                new string[8] { " ", " ", " ", " ", " ", "wk", "wq", " " }

                };
                CreateFigure();
                break;
            case 1:
                _figuresDesk = new string[8][] {
                    new string[8] { "bk", "bq", " ", " ", " ", " ", " ", " "},
                    new string[8] { "bp", "bp", " ", " ", " ", " ", " ", "wo"},
                    new string[8] { " ", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { " ", "wh", " ", " ", " ", " ", " ", " "},
                    new string[8] { " ", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { " ", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { "wq", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { "wr", "wk", " ", " ", " ", " ", "wo", " "}
                };
                CreateFigure();
                break;
            case 2:
                _figuresDesk = new string[8][] {
                    new string[8] { " ", "wo", " ", " ", "bh", " ", " ", " "},
                    new string[8] { " ", " ", " ", "wk", " ", " ", " ", " "},
                    new string[8] { " ", " ", "wh", " ", " ", "wp", " ", " "},
                    new string[8] { "bp", "bp", " ", " ", "wp", " ", " ", " "},
                    new string[8] { "wp", "wp", "bp", "bp", " ", "bo", " ", "bh"},
                    new string[8] { "bk", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { "wo", " ", " ", " ", " ", " ", "wq", " "},
                    new string[8] { " ", " ", " ", " ", " ", " ", " ", " "}
                };
                CreateFigure();
                break;
            case 3:
                _figuresDesk = new string[8][] {
                    new string[8] { "bk", "wo", " ", " ", "wp", " ", " ", " "},
                    new string[8] { " ", " ", "wp", "wp", " ", " ", " ", " "},
                    new string[8] { "wp", "wp", " ", " ", " ", " ", " ", " "},
                    new string[8] { " ", "wp", " ", " ", " ", " ", " ", " "},
                    new string[8] { "wp", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { " ", " ", "wp", " ", " ", " ", " ", " "},
                    new string[8] { " ", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { "wk", " ", " ", " ", " ", " ", " ", " "}
                };
                CreateFigure();
                break;
            case 4:
                _figuresDesk = new string[8][] {
                    new string[8] { "wk", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { " ", "wh", "wo", "wq", " ", "wo", " ", " "},
                    new string[8] { " ", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { " ", "bo", " ", " ", " ", " ", "bo", " "},
                    new string[8] { "bh", " ", " ", " ", "bk", " ", "bh", " "},
                    new string[8] { " ", "wp", " ", " ", " ", " ", "wp", " "},
                    new string[8] { " ", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { "wh", " ", " ", "wr", " ", "wr", " ", " "}
                };
                CreateFigure();
                break;
            case 5:
                _figuresDesk = new string[8][] {
                    new string[8] { "bq", " ", " ", " ", " ", "wr", " ", "wo"},
                    new string[8] { " ", " ", " ", " ", "bp", " ", " ", " "},
                    new string[8] { " ", " ", " ", " ", " ", " ", " ", "wr"},
                    new string[8] { " ", " ", " ", " ", " ", " ", "br", " "},
                    new string[8] { "bh", " ", " ", "br", " ", " ", "bk", " "},
                    new string[8] { "wq", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { " ", " ", " ", " ", " ", " ", "wo", " "},
                    new string[8] { " ", " ", " ", " ", " ", " ", " ", "wk"}
                };
                CreateFigure();
                break;
            case 6:
                _figuresDesk = new string[8][] {
                    new string[8] { "wo", " ", " ", " ", "wq", "wp", " ", "wo"},
                    new string[8] { "bo", " ", " ", "wp", " ", " ", " ", " "},
                    new string[8] { "bo", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { "bq", "wp", " ", " ", "bh", " ", "bh", " "},
                    new string[8] { " ", " ", " ", " ", " ", "wk", "wr", " "},
                    new string[8] { " ", " ", " ", " ", "wh", " ", "wo", " "},
                    new string[8] { "wr", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { "br", " ", " ", " ", "bp", "bp", "bk", "br"}
                };
                CreateFigure();
                break;
            case 7:
                _figuresDesk = new string[8][] {
                    new string[8] { " ", "wq", " ", " ", " ", " ", "br", "bo"},
                    new string[8] { " ", "bp", " ", "bo", "wp", " ", " ", "wr"},
                    new string[8] { " ", " ", "bk", " ", " ", " ", " ", " "},
                    new string[8] { " ", " ", " ", " ", " ", "wh", " ", " "},
                    new string[8] { " ", " ", " ", " ", "wp", " ", " ", " "},
                    new string[8] { " ", " ", " ", "wh", " ", " ", " ", " "},
                    new string[8] { "wo", " ", "bp", " ", " ", " ", " ", " "},
                    new string[8] { "wk", "wr", " ", " ", " ", " ", " ", "br"}
                };
                CreateFigure();
                break;
            case 8:
                _figuresDesk = new string[8][] {
                    new string[8] { "br", " ", " ", " ", " ", " ", "bk", "bo"},
                    new string[8] { "wq", " ", " ", " ", " ", " ", " ", " "},
                    new string[8] { "wk", "wp", "wp", " ", "wh", " ", "wp", " "},
                    new string[8] { "bp", " ", " ", " ", " ", " ", " ", "wp"},
                    new string[8] { " ", " ", "bp", "wh", " ", " ", "wp", " "},
                    new string[8] { " ", " ", "bp", " ", " ", " ", " ", " "},
                    new string[8] { "bp", "bp", " ", " ", " ", " ", " ", " "},
                    new string[8] { " ", "bo", " ", " ", " ", "wr", " ", "wr"}
                };
                CreateFigure();
                break;
        }
    }
    
    public void ChangePositions(Figure figure)
    {
        Transform figureTransform = figure.gameObject.transform;
        Debug.Log($"localPosition.x: {figureTransform.localPosition.x}, _positionsFiguresOnDesk.x: {_positionsFiguresOnDesk.x}");
        Debug.Log($"localPosition.y: {figureTransform.localPosition.y}, _positionsFiguresOnDesk.y: {_positionsFiguresOnDesk.y}");
        int i = ((int)figureTransform.localPosition.x - (int)_positionsFiguresOnDesk.x) / 4;
        int j = Mathf.Abs(((int)figureTransform.localPosition.y - (int)_positionsFiguresOnDesk.y)) / 4;
        if (_figuresDesk[j][i][0] == 'b')
        {
            Figure figureFind = FindFigure(new Vector2(j, i));
            if (figureFind != null)
            {
                GameInput.Instance.FButtons.Remove(figureFind.Interract);
                Destroy(figureFind.gameObject);
            }
        }
        _figuresDesk    
            [j]
            [i] = figure.Nickname;
        _figuresDesk[(int)figure.PositionsIndex.x]
            [(int)figure.PositionsIndex.y] = " ";
        figure.PositionsIndex = new Vector2(j, i);
    }
    public void CheckDesk()
    {
        switch (_numberLevel)
        {
            case 0:
                if (_figuresDesk[4][4] == "wp")
                {
                    _numberLevel++;
                    DialogFunction.Instance.Dialog(1);
                }
                break;
            case 1:
                if (_figuresDesk[1][0] == "wq")
                {
                    _numberLevel++;
                    DialogFunction.Instance.Dialog(2);
                }
                break;
            case 2:
                if (_figuresDesk[5][5] == "wq" || _figuresDesk[5][7] == "wq")
                {
                    _numberLevel++;
                    DialogFunction.Instance.Dialog(3);
                }
                break;
            case 3:
                if (_figuresDesk[1][1] == "wp")
                {
                    _numberLevel++;
                    DialogFunction.Instance.Dialog(4);
                }
                break;
            case 4: 
                if (_figuresDesk[2][4] == "wq")
                {
                    _numberLevel++;
                    DialogFunction.Instance.Dialog(5);
                }
                break;
            case 5:
                if (_figuresDesk[5][5] == "wq" || _figuresDesk[5][7] == "wq")
                {
                    _numberLevel++;
                    DialogFunction.Instance.Dialog(6);
                }
                break;
            case 6:
                if (_figuresDesk[6][7] == "wo")
                {
                    _numberLevel++;
                    DialogFunction.Instance.Dialog(7);
                }
                break;
            case 7:
                if (_figuresDesk[2][1] == "wr")
                {
                    _numberLevel++;
                    DialogFunction.Instance.Dialog(8);
                }
                break;
            case 8:
                if (_figuresDesk[1][7] == "wp")
                {
                    _numberLevel++;
                    DialogFunction.Instance.Dialog(9);
                    Key newKey = Instantiate(key);
                    newKey.gameObject.transform.position = keyPosition;
                }
                break;
            default:
                break;
        }
        ClearDesk();
        StartGame();
    }
    
    private Figure FindFigure(Vector2 positionFigure)
    {
        foreach (var figure in _figures)
        {
            if (figure.PositionsIndex == positionFigure)
            {
                return figure;
            }
        }
        return null;
    }
    
    private void CreateFigure()
    {
        for (int i = 0; i < _figuresDesk[0].Length; ++i)
        {
            for (int j = 0; j < _figuresDesk[i].Length; ++j)
            {
                if (_figuresDesk[i][j] != " ")
                {
                    Figure figure = Instantiate(Figures.Instance.FiguresLevel[_figuresDesk[i][j]],
                                        deskTransform);
                    _figures.Add(figure);
                    Vector3 figurePositions = figure.gameObject.transform.position;
                    figurePositions.x = _positionsFiguresOnDesk.x + j * 4;
                    figurePositions.y = _positionsFiguresOnDesk.y - i * 4;
                    figure.gameObject.transform.position = figurePositions;
                    figure.PositionsIndex = new Vector2(i, j);
                    figure.Nickname = _figuresDesk[i][j];
                    if (_figuresDesk[i][j][0] == 'b')
                    {
                        figure.ChangeButtonVisionFigure(0);
                    }
                }
            }
        }
    }
    private void ClearDesk()
    {
        for (int i = 0; i < _figures.Count; ++i)
        {
            GameInput.Instance.FButtons.Remove(_figures[i].Interract);
            Destroy(_figures[i].gameObject);
            _figures.Remove(_figures[i]);
            i--;
        }
        _figures.Clear();
    }
}
