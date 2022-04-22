//  C# Snake Game
//  By: Adam Elkhanoufi
//  04/21/2022
//
//  Script for the Main Menu screen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text mode;
    public void Play(TMP_Text mode)
    {
        SnakeMoves.Difficulty = mode;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
