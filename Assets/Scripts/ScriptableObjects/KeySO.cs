using UnityEngine;

[CreateAssetMenu(fileName = "KeySO", menuName = "Scriptable Objects/KeySO")]
public class KeySO : ScriptableObject
{
    [SerializeField] public static string nameObject = "Ключ";
    [SerializeField] public Sprite spriteObject = null;
}
