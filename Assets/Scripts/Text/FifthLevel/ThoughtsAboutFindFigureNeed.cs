using UnityEngine;

public class ThoughtsAboutFindFigureNeed : MonoBehaviour
{
    public static ThoughtsAboutFindFigureNeed Instance { get; private set; }
    [SerializeField] private float needTimeWaiting = 10f;
    private float _currentTimeWaiting = 0f;
    private void Update()
    {
        if (GameFourth.Instance.NumberLevel == 8)
        {
            _currentTimeWaiting += Time.deltaTime;
            if (_currentTimeWaiting >= needTimeWaiting)
            {
                DialogFunction.Instance.Monolog(0);
                HireFigure.Instance.ChangeButtonVisionDistance();
                DestroyThisGameObject();

            }
        }
    }
    private void DestroyThisGameObject()
    {
        Destroy(gameObject);
    }
}
