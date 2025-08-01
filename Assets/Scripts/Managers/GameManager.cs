using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Logger log;

    private MapData currentMapData;
    public GameObject player;
    public Dictionary<int, MapData> mapLevel { get; private set; }
    public List<MapData> allMapData= new List<MapData>();

    private int currentHeadCount = 0;
    public int currentLevel = 1;

    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public bool isGameWon = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        log = new Logger("GameManager");

        StartCoroutine(InitStartLevel(currentLevel));
    }

    IEnumerator InitStartLevel(int level)
    {
        yield return StartCoroutine(LoadMapData());
        yield return null;
        SetupMap(level);
        ResetGameStats();
    }

    void Update()
    {
        if (currentMapData && !isGameOver && !isGameWon) CheckWinLose();
    }

    private const string mapPath = "MapData/";
    private IEnumerator LoadMapData()
    {
        mapLevel = new Dictionary<int, MapData>();
        int level = 1;
        string _loadedMapLog = "Loaded Map Data: ";
        foreach (MapData d in allMapData)
        {
            _loadedMapLog += $"{{ {level} : {d.mapName} }}, ";
            mapLevel[level++] = d;
            yield return null;
        }
        if (mapLevel.Count == 0) _loadedMapLog += "None";
        log.Log(_loadedMapLog);
    }

    public void SetupMap(int level)
    {
        if (currentMapData != null) Destroy(currentMapData);

        if (mapLevel[level] == null) return;
        currentMapData = mapLevel[level];
        string sceneName = currentMapData.sceneName;
        if (SceneManager.GetSceneByName(sceneName).IsValid())
            SceneManager.LoadScene(sceneName);
    }

    public void ResetGameStats()
    {
        currentHeadCount = 0;
        isGameOver = false;
        isGameWon = false;
    }

    public void AddHeadCount(int amount)
    {
        currentHeadCount += amount;
    }

    void CheckWinLose()
    {
        if (currentHeadCount >= currentMapData.targetHeadCount) WinGame();
        else if (player == null) LoseGame();
    }

    void WinGame()
    {
        isGameWon = true;
        log.Log("You win!");
    }

    void LoseGame()
    {
        isGameOver = true;
        log.Log("Game Over...");
    }

    public void NextLevel()
    {
        SetupMap(++currentLevel);
        ResetGameStats();
    }
}
