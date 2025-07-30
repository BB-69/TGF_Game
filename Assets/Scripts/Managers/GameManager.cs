using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Logger log;

    private MapData currentMapData;
    public GameObject player;
    private const string mapPath = "MapData/";
    public Dictionary<int, MapData> mapLevel { get; private set; }

    private int currentHeadCount = 0;
    public int currentLevel = 1;

    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public bool isGameWon = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        log = new Logger("GameManager");

        LoadMapData();
        SetupMap(currentLevel);
        ResetGameStats();
    }

    void Update()
    {
        if (!isGameOver && !isGameWon) CheckWinLose();
    }

    private void LoadMapData()
    {
        // loading process here
    }

    public void SetupMap(int level)
    {
        if (currentMapData != null) Destroy(currentMapData);
        currentMapData = mapLevel[level];
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
        Debug.Log("You win!");
    }

    void LoseGame()
    {
        isGameOver = true;
        Debug.Log("Game Over...");
    }

    public void NextLevel()
    {
        SetupMap(++currentLevel);
        ResetGameStats();
    }
}
