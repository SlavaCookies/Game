using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    [SerializeField] private float lineXPosition;
    [SerializeField] private float topYPosition;
    [SerializeField] private float bottomYPosition;
    
    private void Update()
    {
        if (LevelZeroManager.predScene == 7 && 
            Player.Instance.gameObject.transform.localPosition.x <= lineXPosition)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.orange;
        Gizmos.DrawLine(new Vector2(lineXPosition, bottomYPosition), new Vector2(lineXPosition, topYPosition));
    }
}
