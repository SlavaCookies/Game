using System.Diagnostics;
using UnityEngine;

public class Officer : Figure
{
    private void Awake()
    {
        NameFigure = FiguresSO.nameOfficer;
    }

    public override void ActionFigure()
    {
        int i = (int)PositionsIndex.x;
        int j = (int)PositionsIndex.y;
        bool isUpRightLock = false;
        bool isUpLeftLock = false;
        bool isDownRightLock = false;
        bool isDownLeftLock = false;
        CreateOfficer(i, j, isUpRightLock, isUpLeftLock, isDownRightLock, isDownLeftLock);
    }
}
