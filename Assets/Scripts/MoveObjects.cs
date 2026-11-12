using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public static MoveObjects Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void MoveObject(Vector2 inputVector, Rigidbody2D rb)
    {
        rb.MovePosition(rb.position + inputVector *
            (Player.Instance.MovingSpeed * Time.fixedDeltaTime));
    }
}
