using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ThoughtsBegin : MonoBehaviour
{
    private void Start()
    {
        PlayerVisual.Instance.OnResetVisual += ThoughtsBegin_OnResetVisual;
    }

    private void ThoughtsBegin_OnResetVisual(object sender, System.EventArgs e)
    {
        DialogFunction.Instance.Monolog(0);
        DestroyThisObject();
    }
    private void DestroyThisObject()
    {
        PlayerVisual.Instance.OnResetVisual -= ThoughtsBegin_OnResetVisual;
        Destroy(gameObject);
    }
}
