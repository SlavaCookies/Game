using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public static LoadLevel Instance { get; private set; }
    [SerializeField] private int numberScene;
    public EventHandler OnLevelLoading;

    private void Awake()
    {
        Instance = this;
        if (PersistentMusic.Instance != null)
        {
            PersistentMusic.Instance.ZeroLevelStart();
        }
    }
    public void LoadScene()
    {
        ActionsLoad();
        LevelZeroManager.predScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(numberScene);
    }
    
    public void LoadScene(int numberScene)
    {
        ActionsLoad();
        OnLevelLoading?.Invoke(this, EventArgs.Empty);
        SceneManager.LoadScene(numberScene); 
    }
    
    private void ActionsLoad()
    {
        GameInput.Instance.EButtons.Clear();
        GameInput.Instance.FButtons.Clear();
        Player.Instance.IsFreezePlayer = false;
    }
}
