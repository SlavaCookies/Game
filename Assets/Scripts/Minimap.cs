using UnityEngine;

public class Minimap : MonoBehaviour
{
    public static Minimap Instance { get; private set; }
    [SerializeField] private float widthMap = 107.71703f;
    [SerializeField] private float heightMap = 8.8440502f;
    [SerializeField] private float widthMinimap = 3.438f;
    [SerializeField] private float heightMinimap = 0.75f;
    [SerializeField] private float minWidthMap = -6.68163f;
    [SerializeField] private float minHeightMap = -8.504262f;
    [SerializeField] private float minWidthMinimap = -1.719f;
    [SerializeField] private float minHeightMinimap = -0.85f;
    [SerializeField] private GameObject player;
    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer spriteRenderer
    {
        get { return _spriteRenderer; }
        set { _spriteRenderer = value; }
    }
    private void Awake()
    {
        Instance = this;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        MovePlayerOnMinimap();
    }

    private void MovePlayerOnMinimap()
    {
        Vector3 playerPosition = Player.Instance.transform.position;
        playerPosition.x += minWidthMap > 0 ? -minWidthMap : Mathf.Abs(minWidthMap);
        playerPosition.y += minHeightMap > 0 ? -minHeightMap : Mathf.Abs(minHeightMap);
        float proccessPlayerPositionX = playerPosition.x / widthMap;
        float proccessPlayerPositionY = playerPosition.y / heightMap;
        player.transform.localPosition = new Vector3(
            widthMinimap * proccessPlayerPositionX + minWidthMinimap,
            heightMinimap * proccessPlayerPositionY + minHeightMinimap,
            player.transform.localPosition.z);
    }
}
