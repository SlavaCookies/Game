using UnityEngine;

public class Rook : Figure
{
    private void Awake()
    {
        NameFigure = FiguresSO.nameRook;
    }
    public override void ActionFigure()
    {
        int i = (int)PositionsIndex.x;
        int j = (int)PositionsIndex.y;
        bool isUpRookLock = false;
        bool isRightRookLock = false;
        bool isLeftRookLock = false;
        bool isDownRookLock = false;
        CreateRook(i, j, isUpRookLock, isRightRookLock, isLeftRookLock, isDownRookLock);
    }
}
