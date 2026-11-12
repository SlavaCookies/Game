using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class Figure : MonoBehaviour
{
    [SerializeField] private ButtonVision buttonVision;
    [SerializeField] private FigureInterract figureInterract;
    private string _nameFigure;
    private List<ObjectStep> _objectsStep = new List<ObjectStep>();
    private Vector2 _positionsIndex;
    private string _nickname;
    private string[][] _figuresDesk;
    public string NameFigure
    {
        get { return _nameFigure; }
        set { _nameFigure = value; }
    }
    public string Nickname
    {
        get { return _nickname; }
        set { _nickname = value; }
    }
    public Vector2 PositionsIndex
    {
        get { return _positionsIndex; }
        set { _positionsIndex = value; }
    }
    public List<ObjectStep> ObjectsStep
    {
        get { return _objectsStep; }
        set { _objectsStep = value; }
    }
    public string[][] FiguresDesk
    {
        get { return _figuresDesk; }
        set { _figuresDesk = value; }
    }
    public FigureInterract Interract
    {
        get { return figureInterract; }
        set { figureInterract = value; }
    }
    private void Start()
    {
        _figuresDesk = GameFourth.Instance.FiguresDesk;
    }
    public virtual void ActionFigure() { } 
    public void DestroyObjects()
    {
        for (int i = 0; i < _objectsStep.Count; ++i)
        {
            GameInput.Instance.FButtons.Remove(_objectsStep[i]);
            Destroy(_objectsStep[i].gameObject.transform.parent.gameObject);
            _objectsStep.Remove(_objectsStep[i]);
            i--;
        }
    }
    public void CreateObject(int i, int j)
    {
        GameObject newObject = Instantiate(Figures.Instance.StepObject);
        ObjectStep objectStep = newObject.GetComponentInChildren<ObjectStep>();
        objectStep.figure = this;
        Debug.Log(objectStep.figure == null);
        Vector2 objectPosition = new Vector2(GameFourth.Instance.PositionsFiguresOnDesk.x + (j * 4),
            GameFourth.Instance.PositionsFiguresOnDesk.y - (i * 4));  
        _objectsStep.Add(objectStep);
        newObject.gameObject.transform.position = objectPosition;
    }
 
    public void CreatePawn(int i, int j)
    {
        if (i > 0 && FiguresDesk[i - 1][j] == " ")
        {
            CreateObject(i - 1, j);
        }
        if (i > 0 && j < (FiguresDesk[0].Length - 1) && FiguresDesk[i - 1][j + 1][0] == 'b')
        {
            CreateObject(i - 1, j + 1);
        }
        if (i > 0 && j > 0 && FiguresDesk[i - 1][j - 1][0] == 'b')
        {
            CreateObject(i - 1, j - 1);
        }
    }
 
    public void CreateOfficer(int i, int j, bool isUpRightLock, bool isUpLeftLock, bool isDownRightLock, bool isDownLeftLock)
    {
        for (int index = 1; index < FiguresDesk[0].Length; ++index)
        {
            if (i + index < FiguresDesk[0].Length)
            {
                if (!isDownRightLock &&
                    j + index < FiguresDesk[0].Length && (FiguresDesk[i + index][j + index][0] == 'b' ||
                    FiguresDesk[i + index][j + index][0] == ' '))
                {
                    CreateObject(i + index, j + index);
                    if (FiguresDesk[i + index][j + index][0] == 'b')
                    {
                        isDownRightLock = true;
                    }
                }
                else
                {
                    isDownRightLock = true;
                }
                if (!isDownLeftLock &&
                    j - index >= 0 && (FiguresDesk[i + index][j - index][0] == 'b' ||
                    FiguresDesk[i + index][j - index][0] == ' '))
                {
                    CreateObject(i + index, j - index);
                    if (FiguresDesk[i + index][j - index][0] == 'b')
                    {
                        isDownLeftLock = true;
                    }
                }
                else
                {
                    isDownLeftLock = true;
                }
            }
            if (i - index >= 0)
            {
                if (!isUpRightLock &&
                    j + index < FiguresDesk[0].Length && (FiguresDesk[i - index][j + index][0] == 'b' ||
                    FiguresDesk[i - index][j + index][0] == ' '))
                {
                    CreateObject(i - index, j + index);
                    if (FiguresDesk[i - index][j + index][0] == 'b')
                    {
                        isUpRightLock = true;
                    }
                }
                else
                {
                    isUpRightLock = true;
                }
                if (j - index >= 0)
                {
                    Debug.Log($"Object {FiguresDesk[i - index][j - index] == null}");
                    Debug.Log($"i = {i}, j = {j}");
                }
                if (
                    !isUpLeftLock &&
                    j - index >= 0 && (FiguresDesk[i - index][j - index][0] == 'b' ||
                    FiguresDesk[i - index][j - index][0] == ' '))
                {
                    CreateObject(i - index, j - index);
                    if (FiguresDesk[i - index][j - index][0] == 'b')
                    {
                        isUpLeftLock = false;
                    }
                }
                else
                {
                    isUpLeftLock = true;
                }
            }
        }
    }

    public void CreateRook(int i, int j, bool isUpRookLock, bool isRightRookLock, bool isLeftRookLock, bool isDownRookLock)
    {
        for (int index = 1; index < FiguresDesk[0].Length; ++index)
        {
            if (!isDownRookLock && (i + index) < FiguresDesk[0].Length &&
                (FiguresDesk[i + index][j][0] == 'b' || FiguresDesk[i + index][j][0] == ' '))
            {
                CreateObject(i + index, j);
                if (FiguresDesk[i + index][j][0] == 'b')
                {
                    isDownRookLock = true;
                }
            } else
            {
                isDownRookLock = true;
            }
            if (!isRightRookLock && (j + index) < FiguresDesk[0].Length &&
                (FiguresDesk[i][j + index][0] == 'b' || FiguresDesk[i][j + index][0] == ' '))
            {
                CreateObject(i, j + index);
                if (FiguresDesk[i][j + index][0] == 'b')
                {
                    isRightRookLock = true;
                }
            } else
            {
                isRightRookLock = true;
            }
            if (!isUpRookLock && (i - index) >= 0 &&
                (FiguresDesk[i - index][j][0] == 'b' || FiguresDesk[i - index][j][0] == ' '))
            {
                CreateObject(i - index, j);
                if (FiguresDesk[i - index][j][0] == 'b')
                {
                    isUpRookLock = true;
                } 
            } else
            {
                isUpRookLock = true;
            }
            if ((j - index) >= 0)
            {
                Debug.Log($"Object {FiguresDesk[i][j - index] == null}");
                Debug.Log($"i = {i}, j = {j}");     
            }
            if (!isLeftRookLock && (j - index) >= 0 &&
                (FiguresDesk[i][j - index][0] == 'b' || FiguresDesk[i][j - index][0] == ' '))
            {
                CreateObject(i, j - index);
                if (FiguresDesk[i][j - index][0] == 'b')
                {
                    isLeftRookLock = true;
                }
            } else
            {
                isLeftRookLock = true;
            }
        }
    }

    public void CreateHorse(int i, int j)
    {
        if (i - 2 >= 0)
        {
            if (j + 1 < FiguresDesk[0].Length &&
                (FiguresDesk[i - 2][j + 1][0] == 'b' || FiguresDesk[i - 2][j + 1][0] == ' '))
            {
                CreateObject(i - 2, j + 1);
            }
            if (j - 1 >= 0 &&
                (FiguresDesk[i - 2][j - 1][0] == 'b' || FiguresDesk[i - 2][j - 1][0] == ' '))
            {
                CreateObject(i - 2, j - 1);
            }
        }
        if (i + 2 < FiguresDesk[0].Length)
        {
            if (j + 1 < FiguresDesk[0].Length &&
                (FiguresDesk[i + 2][j + 1][0] == 'b' || FiguresDesk[i + 2][j + 1][0] == ' '))
            {
                CreateObject(i + 2, j + 1);
            }
            if (j - 1 >= 0 &&
                (FiguresDesk[i + 2][j - 1][0] == 'b' || FiguresDesk[i + 2][j - 1][0] == ' '))
            {
                CreateObject(i + 2, j - 1);
            }
        }
        if (j - 2 >= 0)
        {
            if (i + 1 < FiguresDesk[0].Length &&
                (FiguresDesk[i + 1][j - 2][0] == 'b' || FiguresDesk[i + 1][j - 2][0] == ' '))
            {
                CreateObject(i + 1, j - 2);
            }
            if (i - 1 >= 0 &&
                (FiguresDesk[i - 1][j - 2][0] == 'b' || FiguresDesk[i - 1][j - 2][0] == ' '))
            {
                CreateObject(i - 1, j - 2);
            }
        }
        if (j + 2 < FiguresDesk[0].Length)
        {

            if (i + 1 < FiguresDesk[0].Length &&
                (FiguresDesk[i + 1][j + 2][0] == 'b' || FiguresDesk[i + 1][j + 2][0] == ' '))
            {
                CreateObject(i + 1, j + 2);
            }
            if (i - 1 >= 0 &&
                (FiguresDesk[i - 1][j + 2][0] == 'b' || FiguresDesk[i - 1][j + 2][0] == ' '))
            {
                CreateObject(i - 1, j + 2);
            }
        }
    }
    public void CreateKing(int i, int j)
    {
        if (i + 1 < FiguresDesk[0].Length &&
            (FiguresDesk[i + 1][j][0] == 'b' || FiguresDesk[i + 1][j][0] == ' '))
        {
            CreateObject(i + 1, j);
        }
        if (i + 1 < FiguresDesk[0].Length && j - 1 >= 0 &&
            (FiguresDesk[i + 1][j - 1][0] == 'b' || FiguresDesk[i + 1][j - 1][0] == ' '))
        {
            CreateObject(i + 1, j - 1);
        }
        if (i + 1 < FiguresDesk[0].Length && j + 1 < FiguresDesk[0].Length &&
            (FiguresDesk[i + 1][j + 1][0] == 'b' || FiguresDesk[i + 1][j + 1][0] == ' '))
        {
            CreateObject(i + 1, j + 1);
        }
        if (i - 1 >= 0 &&
            (FiguresDesk[i - 1][j][0] == 'b' || FiguresDesk[i - 1][j][0] == ' '))
        {
            CreateObject(i - 1, j);
        }
        if (i - 1 >= 0 && j - 1 >= 0 &&
            (FiguresDesk[i - 1][j - 1][0] == 'b' || FiguresDesk[i - 1][j - 1][0] == ' '))
        {
            CreateObject(i - 1, j - 1);
        }
        if (i - 1 >= 0 && j + 1 < FiguresDesk[0].Length && 
            (FiguresDesk[i - 1][j + 1][0] == 'b' || FiguresDesk[i - 1][j + 1][0] == ' '))
        {
            CreateObject(i - 1, j + 1);
        }
        if (j + 1 < FiguresDesk[0].Length &&
            (FiguresDesk[i][j + 1][0] == 'b' || FiguresDesk[i][j + 1][0] == ' '))
        {
            CreateObject(i, j + 1);
        }
        if (j - 1 >= 0 &&
            (FiguresDesk[i][j - 1][0] == 'b' || FiguresDesk[i][j - 1][0] == ' '))
        {
            CreateObject(i, j - 1);
        }
    }

    public void ChangeButtonVisionFigure(bool isHide)
    {
        if (isHide)
        {
            buttonVision.DistanceToView = 0f;
        } else
        {
            buttonVision.DistanceToView = 1f;
        }
    }
    public void ChangeButtonVisionFigure(int vision)
    {
        buttonVision.DistanceToView = vision;
    }
}
