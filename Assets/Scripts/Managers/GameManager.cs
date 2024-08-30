using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentGameState;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ChangeState(GameState.WorldExplored);
        MenuManager.Instance.SaveScene();
    }

    public void Update()
    {

    }

    public void ChangeState(GameState newState)
    {
        CurrentGameState = newState;
        switch (newState)
        {
            case GameState.WorldExplored:
                MenuManager.Instance.ShowPlayerInfo();
                break;
            case GameState.Cinematic:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    public enum GameState
    {
        WorldExplored = 0,
        Cinematic = 8,
    }
}
