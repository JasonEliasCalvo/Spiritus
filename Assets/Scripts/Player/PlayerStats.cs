using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int healthMax;
    public int collectedOrbs;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void DamagePlayer(int damage)
    {
        health -= damage;
        StartCoroutine(AnimDamage());

        if (health <= 0)
        {
            PlayerDeath();
        }
    }
    IEnumerator AnimDamage()
    {
        for (int i = 0; i < 6; i++)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.05f);
        }
    }
    private void PlayerDeath()
    {
        Destroy(gameObject);
        MenuManager.Instance.GameOver.SetActive(true);
    }
}
