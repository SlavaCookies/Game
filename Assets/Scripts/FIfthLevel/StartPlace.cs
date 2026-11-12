using UnityEngine;

public class StartDancePlace : MonoBehaviour
{
    [SerializeField] private float needTimeWait = 1f;
    private float _currentTimeWait = 0f;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        _currentTimeWait += Time.fixedDeltaTime;
        
        if (_currentTimeWait >= needTimeWait)
        {
            FifthLevel.Instance.StartGame();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        _currentTimeWait = 0f;
    }
}
