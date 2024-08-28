using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu comun;
    [SerializeField]
    private GameObject MenuDePausa;
    public bool isPause { get; protected set; }

    private void Awake()
    {
        comun = this;
        Play();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            if (isPause)
                Play();
            else
                Pause();
        }
    }

    public void Pause()
    {
        isPause = true;
        MenuDePausa.SetActive(true);
        Time.timeScale = 0;
    }

    public void Play()
    {
        isPause = false;
        MenuDePausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1;
    }
}
