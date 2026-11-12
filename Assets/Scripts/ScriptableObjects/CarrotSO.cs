using UnityEngine;

[CreateAssetMenu(fileName = "CarrotSO", menuName = "Scriptable Objects/CarrotSO")]
public class CarrotSO : ScriptableObject
{
    [SerializeField] public static string carrotName = "Морковь";
    [SerializeField] public Sprite carrotSprite = null;
}
