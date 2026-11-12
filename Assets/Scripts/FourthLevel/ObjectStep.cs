using UnityEngine;

public class ObjectStep : MonoBehaviour, IInterract
{
    private Figure _figure;
    private bool _isRemove = false;
    private Vector2 _position;
    public Figure figure
    {
        get { return _figure; }
        set { _figure = value; }
    }
    public Vector2 Position
    {
        get { return _position; }
        set { _position = value; }
    }
    private void Start()
    {
        GameInput.Instance.FButtons.Add(this);
    }

    public bool IsActive()
    {
        if (this != null)
        {
            return gameObject.activeSelf;
        } else
        {
            return false;
        }
    }
    public void Interract()
    {
        Vector2 positions = _figure.PositionsIndex;
        _figure.Interract.IsInterract = false;
        _figure.Interract.ChangeButtonVisionFigures(false);
        _figure.gameObject.transform.localPosition = gameObject.transform.parent.gameObject.
            transform.localPosition;
        GameFourth.Instance.ChangePositions(_figure);
        GameFourth.Instance.CheckDesk();
        _figure.DestroyObjects();
    }
    public bool IsRemove()
    {
        if (_isRemove)
        {
            Destroy(gameObject);
        }
        return _isRemove;
    }
}
