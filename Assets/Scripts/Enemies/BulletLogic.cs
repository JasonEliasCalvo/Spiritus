using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage;

    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerStats playerHealth))
        {
            playerHealth.DamagePlayer(damage);
            MenuManager.Instance.ShowPlayerInfo();
            Destroy(gameObject);
        }
    }
}
