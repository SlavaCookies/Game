using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Pawn : Figure
{
    private void Awake()
    {
        NameFigure = FiguresSO.namePawn;
    }

    public override void ActionFigure()
    {
        int i = (int)PositionsIndex.x;
        int j = (int)PositionsIndex.y;
        CreatePawn(i, j);
    }


}
