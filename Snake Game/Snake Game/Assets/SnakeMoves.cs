using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMoves : MonoBehaviour
{
    private Vector2 path = Vector2.right;
    private List<Transform> snakeBody = new List<Transform>();
    public Transform bodyPrefab;

    private void Start()
    {
        //snakeBody = new List<Transform>();
        //snakeBody.Add(this.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            path = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            path = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            path = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            path = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector2(
            Mathf.Round(this.transform.position.x) + path.x,
            Mathf.Round(this.transform.position.y) + path.y
            );

        for (int i = snakeBody.Count - 1; i > 0; i--)
        {
            snakeBody[i].position = snakeBody[i - 1].position;
        }
    }

    private void Eat()
    {
        Transform bodyPart = Instantiate(this.bodyPrefab);
        bodyPart.position = snakeBody[snakeBody.Count - 1].position;
        snakeBody.Add(bodyPart);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Eat();
        }
    }
}