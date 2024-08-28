using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLogic : MonoBehaviour
{
    [SerializeField]
    private Transform shootController;
    [SerializeField]
    private float lineDistance;
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private bool isPlayerInRange;

    [SerializeField]
    private float timeBetweenShots;
    [SerializeField]
    private float lastShotTime;
    [SerializeField]
    private float shotDelay;
    [SerializeField]
    private GameObject enemyBullet;

    [SerializeField]
    private Vector2 shootingDirection = Vector2.right;

    public void Update()
    {
        isPlayerInRange = Physics2D.Raycast(shootController.position, transform.right, lineDistance, playerLayer);

        if (isPlayerInRange)
        {
            if (Time.time > timeBetweenShots + lastShotTime)
            {
                lastShotTime = Time.time;
                Invoke(nameof(Shoot), shotDelay);
            }
        }
    }

    private void Shoot()
    {
        Instantiate(enemyBullet, shootController.position, shootController.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(shootController.position, shootController.position + transform.right * lineDistance);
    }
}
