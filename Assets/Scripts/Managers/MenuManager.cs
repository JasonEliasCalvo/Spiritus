using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private Image healthBarFill;
    [SerializeField] private TextMeshProUGUI playerInfoText;
    [SerializeField] private PlayerStats playerStats;
    public GameObject combatInterface, pauseMenu, GameOver, Victory;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowPlayerInfo()
    {
        combatInterface.SetActive(true);

        if (playerInfoText != null)
        {
            playerInfoText.text = $"Vida: {playerStats.health}/{playerStats.healthMax}\nOrbes: {playerStats.collectedOrbs}";
        }
    }
    public void ShowEnemyInfo()
    {

    }
}
