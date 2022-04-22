//  C# Snake Game
//  By: Adam Elkhanoufi
//  04/21/2022
//
//  Script for the Difficulty slider menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    public TMP_Text sliderText;
   
    //public float ChangeDifficulty()
    //{
    //    return slider.value;
    //}

    private void Start()
    {
        if (!PlayerPrefs.HasKey("difficulty"))
        {
            PlayerPrefs.SetFloat("difficulty", 0);
            Load();
        }
        else
        {
            Load();
        }

        slider.onValueChanged.AddListener((v) =>
        {
            switch (v)
            {
                case 0:
                    sliderText.text = "Easy";
                    break;
                case 1:
                    sliderText.text = "Normal";
                    break;
                case 2:
                    sliderText.text = "Hard";
                    break;
            }
        });
        SaveDifficulty();
    }
    private void Load()
    {
        slider.value = PlayerPrefs.GetFloat("difficulty");
    }
    private void SaveDifficulty()
    {
        PlayerPrefs.SetFloat("difficulty", slider.value);
    }
}
