using UnityEngine;

public class Horse : Figure
{
    private void Awake()
    {
        NameFigure = FiguresSO.nameHorse;
    }
    public override void ActionFigure()
    {
        int i = (int)PositionsIndex.x;
        int j = (int)PositionsIndex.y;
        CreateHorse(i, j);
    }




}
