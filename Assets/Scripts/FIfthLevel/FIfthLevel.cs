using UnityEngine;
using System.Collections.Generic;
using Unity.Cinemachine;
using System.Collections;
public class FifthLevel : MonoBehaviour
{
    public static FifthLevel Instance { get; private set; }
    [SerializeField] private NumbersAfterStartDanceLevel numbersAfterStartDanceLevel;
    [SerializeField] private StartDancePlace startDancePlace;
    [SerializeField] private CinemachineCamera cameraMain;
    [SerializeField] private Vector3 positionCamera;
    [SerializeField] private float movingTimeCamera = 1f;
    [SerializeField] private float intervalHireTiles = 0.5f;
    [SerializeField] private float timeActiveAllTilesStart = 1f;
    [SerializeField] private Color targetColorRed;
    [SerializeField] private Color targetColorGreen;
    [SerializeField] private Vector3 positionToTeleportMainCharacter;
    [SerializeField] private Key key;
    [SerializeField] private Vector3 keyPosition;
    private Tile[][] _tiles = new Tile[10][];
    private Vector3 _predPositionCamera;
        private Transform _followObject;
    private float _currentTimeMoving = 0f;
    private bool _isCameraMoving = false;
    private int _numberSequenceTiles = 0;
    private CinemachineConfiner2D _confiner;
    private bool _isLevelStart = false;

    private Vector2[][] _sequencesTiles = new Vector2[10][]
    {
        new Vector2[] { new Vector2(9, 0), new Vector2(9, 1), new Vector2(9, 2), new Vector2(9, 3), new Vector2(9, 4),
        new Vector2(9, 5), new Vector2(9, 6), new Vector2(9, 7), new Vector2(9, 8), new Vector2(9, 9),
        new Vector2(8, 9), new Vector2(7, 9), new Vector2(7, 8), new Vector2(7, 7), new Vector2(7, 6),
        new Vector2(7, 5), new Vector2(7, 4), new Vector2(7, 3), new Vector2(7, 2), new Vector2(7, 1),
        new Vector2(7, 0), new Vector2(6, 0), new Vector2(5, 0), new Vector2(5, 1), new Vector2(5, 2), new Vector2(5, 3), new Vector2(5, 4),
        new Vector2(5, 5), new Vector2(5, 6), new Vector2(5, 7), new Vector2(5, 8), new Vector2(5, 9),
        new Vector2(4, 9), new Vector2(3, 9), new Vector2(3, 8), new Vector2(3, 7), new Vector2(3, 6),
        new Vector2(3, 5), new Vector2(3, 4), new Vector2(3, 3), new Vector2(3, 2), new Vector2(3, 1),
        new Vector2(3, 0), new Vector2(2, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(1, 2),
        new Vector2(1, 3), new Vector2(1, 4), new Vector2(1, 5), new Vector2(1, 6), new Vector2(1, 7), new Vector2(1, 8),
        new Vector2(1, 9), new Vector2(0, 9), new Vector2(0, 8), new Vector2(0, 7), new Vector2(0, 6), new Vector2(0, 5),
        new Vector2(0, 4), new Vector2(0, 3), new Vector2(0, 2), new Vector2(0, 1), new Vector2(0, 0)},
        new Vector2[] { new Vector2(9, 4), new Vector2(8, 4), new Vector2(7, 4), new Vector2(7, 3), new Vector2(7, 2), new Vector2(6, 2), new Vector2(5, 2), new Vector2(5, 3), new Vector2(5, 4),
        new Vector2(5, 5), new Vector2(5, 6), new Vector2(6, 6), new Vector2(6, 7), new Vector2(5, 7), new Vector2(4, 7),
        new Vector2(3, 7), new Vector2(3, 6), new Vector2(3, 5), new Vector2(3, 4), new Vector2(3, 3), new Vector2(2, 3),
        new Vector2(1, 3), new Vector2(0, 3)},
        new Vector2[] { new Vector2(9, 9), new Vector2(8, 9), new Vector2(7, 9), new Vector2(6, 9), new Vector2(5, 9),
        new Vector2(5, 8), new Vector2(6, 8), new Vector2(6, 7), new Vector2(7, 7), new Vector2(7, 6),
        new Vector2(7, 5), new Vector2(6, 5), new Vector2(6, 6), new Vector2(5, 6), new Vector2(5, 7),
        new Vector2(4, 7), new Vector2(4, 6), new Vector2(3, 6), new Vector2(3, 5), new Vector2(4, 5), new Vector2(5, 5), new Vector2(5, 4), new Vector2(4, 4), new Vector2(3, 4),
        new Vector2(2, 4), new Vector2(1, 4), new Vector2(0, 4)},
        new Vector2[] { new Vector2(9, 3), new Vector2(8, 3), new Vector2(8, 4), new Vector2(8, 5), new Vector2(7, 5),
        new Vector2(6, 5), new Vector2(5, 5), new Vector2(5, 6), new Vector2(5, 7), new Vector2(6, 7), new Vector2(7, 7), new Vector2(7, 6), new Vector2(7, 4), new Vector2(7, 3),
        new Vector2(7, 2), new Vector2(6, 2), new Vector2(5, 2), new Vector2(4, 2), new Vector2(3, 2),
        new Vector2(2, 2), new Vector2(2, 3), new Vector2(2, 4), new Vector2(3, 4), new Vector2(4, 4), new Vector2(4, 3), new Vector2(4, 1), new Vector2(4, 0), new Vector2(3, 0),
        new Vector2(2, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(1, 2), new Vector2(1, 3), new Vector2(1, 4), new Vector2(1, 5), new Vector2(1, 6), new Vector2(1, 7),
        new Vector2(1, 8), new Vector2(1, 9), new Vector2(2, 9), new Vector2(3, 9), new Vector2(4, 9),
        new Vector2(4, 8), new Vector2(4, 7), new Vector2(3, 7), new Vector2(2, 7), new Vector2(0, 7)},
        new Vector2[] { new Vector2(9, 8), new Vector2(8, 8), new Vector2(7, 8), new Vector2(6, 8), new Vector2(5, 8),
        new Vector2(4, 8), new Vector2(3, 8), new Vector2(2, 8), new Vector2(1, 8), new Vector2(0, 8),
        new Vector2(0, 9), new Vector2(1, 9), new Vector2(1, 7), new Vector2(1, 6), new Vector2(1, 5),
        new Vector2(1, 4), new Vector2(1, 3), new Vector2(1, 2), new Vector2(1, 1), new Vector2(1, 0),
        new Vector2(0, 0), new Vector2(0, 1), new Vector2(2, 1), new Vector2(3, 1), new Vector2(4, 1),
        new Vector2(5, 1), new Vector2(6, 1), new Vector2(7, 1), new Vector2(8, 1), new Vector2(9, 1),
        new Vector2(9, 0), new Vector2(8, 0), new Vector2(8, 2), new Vector2(8, 3),
        new Vector2(8, 4), new Vector2(8, 5), new Vector2(8, 6), new Vector2(8, 7), new Vector2(8, 9), new Vector2(9, 9), new Vector2(9, 7), new Vector2(9, 6), new Vector2(9, 5),
        new Vector2(9, 4), new Vector2(9, 3), new Vector2(9, 2), new Vector2(7, 2), new Vector2(6, 2),
        new Vector2(5, 2), new Vector2(4, 2), new Vector2(3, 2), new Vector2(2, 2), new Vector2(0, 2)},
        new Vector2[] { new Vector2(9, 9), new Vector2(9, 8), new Vector2(8, 8), new Vector2(8, 7), new Vector2(7, 7),
        new Vector2(7, 6), new Vector2(6, 6), new Vector2(6, 5), new Vector2(5, 5), new Vector2(5, 4),
        new Vector2(4, 4), new Vector2(4, 3), new Vector2(3, 3), new Vector2(3, 2), new Vector2(2, 2),
        new Vector2(2, 3), new Vector2(1, 3), new Vector2(1, 4), new Vector2(2, 4), new Vector2(2, 5),
        new Vector2(1, 5), new Vector2(0, 5), new Vector2(0, 6), new Vector2(1, 6), new Vector2(1, 7),
        new Vector2(1, 8), new Vector2(1, 9), new Vector2(0, 9)},
        new Vector2[] { new Vector2(9, 4), new Vector2(8, 4), new Vector2(8, 5), new Vector2(9, 5), new Vector2(9, 6),
        new Vector2(8, 6), new Vector2(8, 7), new Vector2(9, 7), new Vector2(9, 8), new Vector2(8, 8), new Vector2(7, 8), new Vector2(6, 8), new Vector2(5, 8), new Vector2(4, 8),
        new Vector2(3, 8), new Vector2(2, 8), new Vector2(1, 8), new Vector2(0, 8)},
        new Vector2[] { new Vector2(9, 3), new Vector2(8, 3), new Vector2(8, 2), new Vector2(8, 1), new Vector2(8, 0),
        new Vector2(7, 0), new Vector2(6, 0), new Vector2(5, 0), new Vector2(5, 1), new Vector2(5, 2), new Vector2(5, 3), new Vector2(6, 3), new Vector2(6, 4), new Vector2(6, 5), new Vector2(7, 5),
        new Vector2(7, 6), new Vector2(7, 7), new Vector2(6, 7), new Vector2(5, 7), new Vector2(5, 6),
        new Vector2(4, 6), new Vector2(4, 5), new Vector2(4, 4), new Vector2(3, 4), new Vector2(3, 3),
        new Vector2(3, 2), new Vector2(3, 1), new Vector2(4, 1), new Vector2(4, 0), new Vector2(3, 0),
        new Vector2(2, 0), new Vector2(2, 1), new Vector2(2, 2), new Vector2(1, 2), new Vector2(1, 3),
        new Vector2(2, 3), new Vector2(2, 4), new Vector2(1, 4), new Vector2(0, 4)},
        new Vector2[] { new Vector2(9, 8), new Vector2(8, 8), new Vector2(7, 8), new Vector2(6, 8), new Vector2(5, 8),
        new Vector2(5, 7), new Vector2(5, 6), new Vector2(6, 6), new Vector2(6, 5), new Vector2(6, 4),
        new Vector2(6, 3), new Vector2(5, 3), new Vector2(4, 3), new Vector2(3, 3), new Vector2(3, 4),
        new Vector2(3, 5), new Vector2(2, 5), new Vector2(1, 5), new Vector2(1, 4), new Vector2(1, 3), new Vector2(1, 2), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0)},
        new Vector2[] { new Vector2(0, 9), new Vector2(1, 9), new Vector2(2, 9), new Vector2(3, 9), new Vector2(4, 9),
        new Vector2(4, 8), new Vector2(4, 7), new Vector2(4, 6), new Vector2(4, 5), new Vector2(5, 5),
        new Vector2(6, 5), new Vector2(6, 4), new Vector2(6, 3), new Vector2(7, 3), new Vector2(8, 3),
        new Vector2(9, 3), new Vector2(9, 2), new Vector2(8, 2), new Vector2(7, 2), new Vector2(6, 2),
        new Vector2(5, 2), new Vector2(5, 3), new Vector2(5, 4), new Vector2(7, 4), new Vector2(8, 4),
        new Vector2(8, 5), new Vector2(8, 6), new Vector2(8, 7), new Vector2(8, 8), new Vector2(7, 8),
        new Vector2(6, 8), new Vector2(5, 8), new Vector2(3, 8), new Vector2(2, 8), new Vector2(2, 7), new Vector2(2, 6), new Vector2(2, 5), new Vector2(2, 4), new Vector2(2, 3),
        new Vector2(2, 2), new Vector2(1, 2), new Vector2(1, 3), new Vector2(1, 4), new Vector2(1, 5), new Vector2(1, 6), new Vector2(0, 6), new Vector2(0, 5), new Vector2(0, 4),
        new Vector2(0, 3), new Vector2(0, 2), new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1), new Vector2(3, 1), new Vector2(4, 1), new Vector2(4, 0), new Vector2(3, 0), new Vector2(2, 0),
        new Vector2(1, 0), new Vector2(0, 0)}
    };
    private List<Vector2> _currentSequenceTiles = new List<Vector2>();
    public bool IsLevelStart
    {
        get { return _isLevelStart; }
        set { _isLevelStart = value; }
    }
    public List<Vector2> CurrentSequenceTiles
    {
        get { return _currentSequenceTiles; }
        set { _currentSequenceTiles = value; }
    }
    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < _tiles.Length; ++i)
        {
            _tiles[i] = new Tile[10];
        }
        _confiner = cameraMain.GetComponent<CinemachineConfiner2D>();
        PersistentMusic.Instance.UpdateDanceFloor();
    }
    private void Start()
    {
        ButtonView.Instance.gameObject.SetActive(false);
        StartCoroutine(GameProccess());
    }

    private void FixedUpdate()
    {
        if (_isCameraMoving)
        {
            if (_currentTimeMoving <= movingTimeCamera)
            {
                MoveCameraToObjectLevel(_predPositionCamera, positionCamera);
                _currentTimeMoving += Time.fixedDeltaTime;
            }

        } else
        {
            _currentTimeMoving = 0f;
        }
    }

    public void AddTileToTiles(Tile tile)
    {
        _tiles[(int)tile.Indexes.x][(int)tile.Indexes.y] = tile;
    }

    public void AddTileToSequenceTilesAndCheckSequenceTiles(Tile tile)
    {
        _currentSequenceTiles.Add(tile.Indexes);
        int lengthSequenceTiles = _currentSequenceTiles.Count - 1;
        if (_currentSequenceTiles[lengthSequenceTiles] !=
            _sequencesTiles[_numberSequenceTiles][lengthSequenceTiles])
        {
            StartCoroutine(ColorTiles(false));
            if (ButtonView.Instance.IsActiveButton)
            {
                ButtonView.Instance.ViewAction();
            }
            ButtonView.Instance.gameObject.SetActive(false);
            _isLevelStart = false;
        } 
        else if (_currentSequenceTiles.Count == _sequencesTiles[_numberSequenceTiles].Length)
        {
            StartCoroutine(ColorTiles(true));
            _numberSequenceTiles++;
            NumberSequenceUpdated();
            if (ButtonView.Instance.IsActiveButton)
            {
                ButtonView.Instance.ViewAction();
            }
            ButtonView.Instance.gameObject.SetActive(false);
            _isLevelStart = false;
            if (_numberSequenceTiles == 10)
            {
                GameObject newKey = Instantiate(key.gameObject);
                newKey.gameObject.transform.localPosition = keyPosition;
            }
        }
    }

    public void StartGame()
    {
        Player.Instance.IsFreezePlayer = true;
        numbersAfterStartDanceLevel.NumbersAnimationStart();
    }
    
    public void StartSequence()
    {
        _isCameraMoving = true;
    }

    public void CreateDancePlace()
    {
        startDancePlace.gameObject.SetActive(true);
    }
    private IEnumerator WaitDialogToStartMonolog(int index)
    {
        yield return new WaitUntil(() => !DialogFunction.Instance.IsDialogActive);
        DialogFunction.Instance.Monolog(index);
    }
    private void NumberSequenceUpdated()
    {
        if (_numberSequenceTiles == 1)
        {
            DialogFunction.Instance.Dialog(1);
        } else if (_numberSequenceTiles == 5)
        {
            DialogFunction.Instance.Dialog(2);
            StartCoroutine(WaitDialogToStartMonolog(1));
        } else if (_numberSequenceTiles == 9)
        {
            DialogFunction.Instance.Dialog(3);
            StartCoroutine(WaitDialogToStartMonolog(2));
        } else if (_numberSequenceTiles == 10)
        {
            DialogFunction.Instance.Dialog(4);
        }
    }
    private IEnumerator GameProccess()
    {
        yield return new WaitUntil(() => _isCameraMoving);
        _followObject = cameraMain.Follow;
        cameraMain.Follow = null;
        _confiner.enabled = false;
        ButtonView.Instance.ViewAction();

        yield return StartCoroutine(MoveCameraToObjectLevel(cameraMain.transform.position,
            positionCamera));
        _isCameraMoving = false;

        yield return StartCoroutine(ShowAndResetAllTiles());
        _isLevelStart = true;

        yield return StartCoroutine(ShowSequenceTiles());
        yield return StartCoroutine(ResetAllCurrentSequenceTiles());

        yield return new WaitUntil(() => _isCameraMoving);
        yield return StartCoroutine(MoveCameraToObjectLevel(positionCamera,
            cameraMain.transform.position));

        cameraMain.Follow = _followObject;
        Player.Instance.IsFreezePlayer = false;
        _confiner.enabled = true;
        ButtonView.Instance.ViewAction();
        ButtonView.Instance.gameObject.SetActive(true);

        _isCameraMoving = false;
        yield return StartCoroutine(GameProccess());
    }
    private IEnumerator MoveCameraToObjectLevel(Vector3 firstPosition, Vector3 secondPosition)
    {
        float elapsed = 0f;
        while (elapsed < movingTimeCamera)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / movingTimeCamera;
            Vector3 position = cameraMain.transform.position;
            position = Vector3.Lerp(firstPosition, secondPosition, t);
            cameraMain.transform.position = position;
            yield return null;
        }
        cameraMain.transform.position = secondPosition;
    }

    private IEnumerator ShowSequenceTiles()
    {
        Vector2[] sequenceTiles = _sequencesTiles[_numberSequenceTiles];
        for (int i = 0; i < sequenceTiles.Length; ++i)
        {
            _tiles[(int)sequenceTiles[i].x][(int)sequenceTiles[i].y].SetColor();
            yield return new WaitForSeconds(intervalHireTiles);
        }
        for (int i = 0; i < sequenceTiles.Length; ++i)
        {
            _tiles[(int)sequenceTiles[i].x][(int)sequenceTiles[i].y].ResetColor();
        }
    }

    private IEnumerator ShowAndResetAllTiles()
    {
        for (int i = 0; i < _tiles.Length; ++i)
        {
            for (int j = 0; j < _tiles[i].Length; ++j)
            {
                _tiles[i][j].SetColor();
            }
        }
        yield return new WaitForSeconds(timeActiveAllTilesStart);
        for (int i = 0; i < _tiles.Length; ++i)
        {
            for (int j = 0; j < _tiles.Length; ++j)
            {
                _tiles[i][j].ResetColor();
            }
        }
        _isCameraMoving = true;
    }

    private IEnumerator ResetAllCurrentSequenceTiles()
    {
        foreach (var tileIndexes in _currentSequenceTiles)
        {
            _tiles[(int)tileIndexes.x][(int)tileIndexes.y].ResetColor();
        }
        yield return null;
    }
    
    private IEnumerator ColorTiles(bool isSequenceCorrect)
    {
        Debug.Log("Color");
        List<Tile> tiles = new List<Tile>();
        Debug.Log(isSequenceCorrect);
        if (!isSequenceCorrect)
        {
            Debug.Log("isSequenceCorrect");
            Player.Instance.IsFreezePlayer = true;
            for (int i = 0; i < _currentSequenceTiles.Count; ++i)
            {
                tiles.Add(_tiles[(int)_currentSequenceTiles[i].x][(int)_currentSequenceTiles[i].y]);
                tiles[i].SetColorRed();
            }
            Debug.Log(tiles);
            yield return StartCoroutine(PulseColorTiles(tiles, targetColorRed));
            Debug.Log("PulseColorTilesSLSLSSLSLSL");
            yield return StartCoroutine(ResetAllCurrentSequenceTiles());
            Player.Instance.transform.localPosition = positionToTeleportMainCharacter;
            Player.Instance.IsFreezePlayer = false;
        } else
        {
            for (int i = 0; i < _currentSequenceTiles.Count; ++i)
            {
                tiles.Add(_tiles[(int)_currentSequenceTiles[i].x][(int)_currentSequenceTiles[i].y]);
                tiles[i].SetColorGreen();
            }
            yield return StartCoroutine(PulseColorTiles(tiles, targetColorGreen));
            yield return StartCoroutine(ResetAllCurrentSequenceTiles());
            
        }
        if (_numberSequenceTiles != 10)
        {
            startDancePlace.gameObject.SetActive(true);
        }
        _currentSequenceTiles.Clear();
        yield return null;     
    }
    private IEnumerator PulseColorTiles(List<Tile> tiles, Color targetColor)
    {

        int pulseCount = 2;
        float pulseDuration = 1f;
        Color originalRedColor = tiles[0].spriteRenderer.color;
        for (int i = 0; i < pulseCount; ++i)
        {
            float elapsed = 0f;

            while (elapsed < pulseDuration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Sin(elapsed / pulseDuration * Mathf.PI);

                Color currentColor = Color.Lerp(originalRedColor, targetColor, t);
                foreach (var tile in tiles)
                {
                    tile.SetColor(currentColor);
                }
                Debug.Log("tiles");
                yield return null;
            }
        }
        foreach (var tile in tiles)
        {
            Color color = tile.spriteRenderer.color;
            color.r = 255;
            color.g = 255;
            color.b = 255;
            color.a = 255;
        }
    }  
}
