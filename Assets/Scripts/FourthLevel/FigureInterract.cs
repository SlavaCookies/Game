using UnityEngine;
using System.Collections.Generic;

public class FigureInterract : MonoBehaviour, IInterract
{
    [SerializeField] private Figure figure;
    private bool _isRemove = false;
    private bool _isInterract = false;
    private List<Figure> figureObjects = new List<Figure>();
    public bool IsInterract
    {
        get { return _isInterract; }
        set { _isInterract = value; }
    }
    private void Start()
    {
        GameInput.Instance.FButtons.Add(this);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void Interract()
    {
        figureObjects = GameFourth.Instance.ObjectsFigures;
        if (!_isInterract)
        {
            _isInterract = true;
            figure.ActionFigure();
            ChangeButtonVisionFigures(_isInterract);
        } else
        {
            _isInterract = false;
            figure.DestroyObjects();
            ChangeButtonVisionFigures(_isInterract);
        }
    }
    public bool IsRemove()
    {
        return _isRemove;
    }

    public void ChangeButtonVisionFigures(bool isInterract)
    {
        foreach (var objectFigure in figureObjects)
        {
            if (objectFigure != figure && objectFigure.Nickname[0] != 'b')
            {
                objectFigure.ChangeButtonVisionFigure(isInterract);
            }
        }
    }
}
