using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentMusic : MonoBehaviour
{
    public static PersistentMusic Instance { get; private set; }
    [SerializeField] private AudioClip danceFloorClip;
    [SerializeField] private AudioClip basicMusicBackground;
    private AudioSource _audioSource;
    private void Awake()
    {
        Instance = this;
        if (FindObjectsByType<PersistentMusic>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();
    }
    public void ZeroLevelStart() {
        LoadLevel.Instance.OnLevelLoading += Level_Loading;
    }
    public void UpdateDanceFloor()
    {
        _audioSource.clip = danceFloorClip;
        _audioSource.Play();
    }
    public void UpdateRoomKnowledge()
    {
        _audioSource.clip = basicMusicBackground;
        _audioSource.Play();
    }

    private void Level_Loading(object sender, EventArgs e)
    {
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            _audioSource.clip = danceFloorClip;
            _audioSource.Play();
        } else if (_audioSource.clip == danceFloorClip)
        {
            _audioSource.clip = basicMusicBackground;
            _audioSource.Play();
        }
    }
}
