using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private float maxX;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnRate;

    private bool isGameStarted = false;
    private int score = 0;

    // Ensure the instance is not destroyed when loading a new scene
    private void Awake()
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

    private void Update() 
    {
        if (Input.GetMouseButton(0) && !isGameStarted)
        {
            StartSpawning();

            isGameStarted = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        CancelInvoke();
        isGameStarted = false;
        score = 0;
    }

    private void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnBlock), 0.5f, spawnRate);
    }

    private void SpawnBlock()
    {
        Vector2 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX,maxX);

        Instantiate(blockPrefab, spawnPos, Quaternion.identity);

        score++;
    }

    public int GetScore()
    {
        return score;
    } 
    public bool IsGameStarted()
    {
        return isGameStarted;
    }
}
