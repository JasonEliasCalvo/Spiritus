using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    [SerializeField]
    private int damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           PlayerStats playerHealt = other.gameObject.GetComponent<PlayerStats>();
           playerHealt.DamagePlayer(damage);
           MenuManager.Instance.ShowPlayerInfo();
        }
    }
}
