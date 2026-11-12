using UnityEngine;

public class King : Figure
{
    private void Awake()
    {
        NameFigure = FiguresSO.nameKing;
    }
    public override void ActionFigure()
    {
        int i = (int)PositionsIndex.x;
        int j = (int)PositionsIndex.y;
        CreateKing(i, j);
    }





}
