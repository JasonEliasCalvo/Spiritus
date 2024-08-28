using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMovement : MonoBehaviour
{
    [SerializeField] private Transform[] movementPoints;
    [SerializeField] private float speed;

    private int nextPosition = 1;
    private bool plataformOrder = true;

    private void Update()
    {
        if (plataformOrder && nextPosition + 1 >= movementPoints.Length)
            plataformOrder = false;
        if (!plataformOrder && nextPosition <= 0)
            plataformOrder = true;

        if (Vector2.Distance(transform.position, movementPoints[nextPosition].position) < 0.001f)
        {
            if (plataformOrder)
                nextPosition += 1;
            else
                nextPosition -= 1;
        }
        transform.position = Vector2.MoveTowards(transform.position, movementPoints[nextPosition].position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
            other.transform.SetParent(this.transform);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
            other.transform.SetParent(null);
    }
}
