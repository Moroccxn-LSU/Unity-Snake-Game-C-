//  C# Snake Game
//  By: Adam Elkhanoufi
//  04/21/2022
//
//  Script for the Snake

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SnakeMoves : MonoBehaviour
{
    private Vector2 path = Vector2.right;
    private Vector2 input;
    private List<Transform> snakeBody = new List<Transform>();
    public Transform bodyPrefab;
    public int initialSize = 3;
    public static TMP_Text Difficulty;

    private void Start()
    {
        
        Restart();
        if (Difficulty.text == "Easy")
        {
            Time.fixedDeltaTime = 0.06f;
        }
        else if (Difficulty.text == "Normal")
        {
            Time.fixedDeltaTime = 0.046f;
        }
        else if (Difficulty.text == "Hard")
        {
            Time.fixedDeltaTime = 0.04f;
        }
    }
    private void Restart()
    {
        for (int i = 1; i < snakeBody.Count; i++)
        {
            Destroy(snakeBody[i].gameObject);
        }

        snakeBody.Clear();
        snakeBody.Add(this.transform);

        for(int i = 1; i < this.initialSize; i++)
        {
            Eat();
        }

        this.transform.position = Vector3.zero;

        ScoreSystem.location.resetPoints();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (path.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                path = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                path = Vector2.down;
            }
        }
        else if (path.y != 0f) {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                path = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                path = Vector2.right;
            }
        }
    }
    private void FixedUpdate()
    {
        if (input != Vector2.zero)
        {
            path = input;
        }

        for (int i = snakeBody.Count - 1; i > 0; i--)
        {
            snakeBody[i].position = snakeBody[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + path.x,
            Mathf.Round(this.transform.position.y) + path.y,
            0.0f
            );
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
        else if (other.tag == "Deadzone")
        {
            Restart();
        }
    }
}
