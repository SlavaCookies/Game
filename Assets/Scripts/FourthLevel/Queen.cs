using UnityEngine;

public class Queen : Figure
{
    private void Awake()
    {
        NameFigure = FiguresSO.nameQueen;
    }
    public override void ActionFigure()
    {
        int i = (int)PositionsIndex.x;
        int j = (int)PositionsIndex.y;
        bool isUpRightLock = false;
        bool isUpLeftLock = false;
        bool isDownRightLock = false;
        bool isDownLeftLock = false;
        bool isUpQueenLock = false;
        bool isRightQueenLock = false;
        bool isLeftQueenLock = false;
        bool isDownQueenLock = false;
        CreateOfficer(i, j, isUpRightLock, isUpLeftLock, isDownRightLock, isDownLeftLock);
        CreateRook(i, j, isUpQueenLock, isRightQueenLock, isLeftQueenLock, isDownQueenLock);
        CreateKing(i, j);
    }
}
