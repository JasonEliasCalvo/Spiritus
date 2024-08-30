using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private Image[] healthBarFill;
    [SerializeField] private Sprite[] healthBarSprites;
    [SerializeField] private PlayerStats playerStats;
    public GameObject combatInterface, pauseMenu, GameOver, Victory;
    int clampedHealth;

    private void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Victory.SetActive(true);
        }
    }

    public void SaveScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastSceneIndex", currentSceneIndex);
        PlayerPrefs.Save();
    }

    private void UpdateHealthBar()
    {
        clampedHealth = Mathf.Clamp(playerStats.health, 0, playerStats.healthMax);

        if (clampedHealth > 0 && clampedHealth <= healthBarSprites.Length)
        {
            healthBarFill[0].sprite = healthBarSprites[clampedHealth - 1];
        }
    }

    public IEnumerator AnimDamage()
    {
        for (int i = 0; i < 6; i++)
        {
            healthBarFill[1].enabled = !healthBarFill[1].enabled;
            yield return new WaitForSeconds(0.05f);
        }
        healthBarFill[1].sprite = healthBarSprites[clampedHealth - 1];
    }
    public void ShowPlayerInfo()
    {
        combatInterface.SetActive(true);
        UpdateHealthBar();
        if (playerStats.health < 5)
        {
            StartCoroutine(AnimDamage());
        }    
    }
    public void ShowEnemyInfo()
    {

    }
}
