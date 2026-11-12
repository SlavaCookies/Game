using UnityEngine;

public class PutFigure : MonoBehaviour, IInterract
{
    public static PutFigure Instance { get; private set; }
    [SerializeField] private Transform deskTransform;
    [SerializeField] private Vector2 positionsIndex;
    private bool _isRemove = false;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameInput.Instance.FButtons.Add(this);  
    }
    public bool IsActive()
    {
        if (Instance == null)
        {
            return false;
        }
        return gameObject.activeSelf;
    }
    public void Interract()
    {
        if (PlayerObject.Instance.NameObject == FiguresSO.namePawn)
        {
            Figure newFigure = Instantiate(Figures.Instance.FiguresLevel[FiguresSO.nicknameWhitePawn],
                deskTransform);
            GameFourth.Instance.figures.Add(newFigure);
            Vector3 figurePosition = newFigure.gameObject.transform.position;
            figurePosition.x = GameFourth.Instance.PositionsFiguresOnDesk.x + positionsIndex.y * 4;
            figurePosition.y = GameFourth.Instance.PositionsFiguresOnDesk.y - positionsIndex.x * 4;
            newFigure.gameObject.transform.position = figurePosition;
            newFigure.PositionsIndex = positionsIndex;
            GameFourth.Instance.FiguresDesk[(int)positionsIndex.x][(int)positionsIndex.y] =
                FiguresSO.nicknameWhitePawn;
            newFigure.Nickname = GameFourth.Instance.FiguresDesk[(int)positionsIndex.x][(int)positionsIndex.x];
            BackpackOpen.Instance.DeleteItemFromInventory(PlayerObject.Instance.NameObject);
            PlayerObject.Instance.ClearPlayerObjectItemInventory();
            
            _isRemove = true;
        }
    }
    public bool IsRemove()
    {
        if (_isRemove)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        return _isRemove;
    }
}
