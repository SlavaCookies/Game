using UnityEngine;

public class ButtonVision : MonoBehaviour
{
    [SerializeField] private GameObject buttonToView;
    [SerializeField] private float distanceToView;
    public float DistanceToView
    {
        get { return distanceToView; }
        set { distanceToView = value; }
    }

    private void Update()
    {
        if (buttonToView != null)
        {
            Vector2 playerPos = Player.Instance.transform.position;
            float distanceX = transform.position.x - playerPos.x;
            float distanceY = transform.position.y - playerPos.y;
            if (Mathf.Sqrt(distanceX * distanceX + distanceY * distanceY) <= distanceToView)
            {
                buttonToView.SetActive(true);
            }
            else
            {
                buttonToView.SetActive(false);
            }
        }
    }
}
