using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Box box;

    public Transform GetBoxTransform()
    {
        return box.transform;
    }
}
