using UnityEngine;

public class ESCMenu : MonoBehaviour
{
    private void Awake()
    {
        Player.Instance.IsFreezePlayer = true;
    }
    public void ContinueGame()
    {
        Player.Instance.IsFreezePlayer = false;
        Destroy(gameObject);
    }
    public void MainMenu()
    {
        LoadLevel.Instance.LoadScene(0);
    }   
}
