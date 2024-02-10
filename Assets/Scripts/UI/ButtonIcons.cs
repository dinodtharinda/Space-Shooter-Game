using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonIcons : MonoBehaviour
{
    [SerializeField] private Button[] lvlButton;
    [SerializeField] private Sprite unlockedIcon;
    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private int firstLevelBuildIndex;
    ButtonController buttonController = new ButtonController();
    private void Awake()
    {

        int unlockedLvl = PlayerPrefs.GetInt("LevelUnlock", firstLevelBuildIndex);
        for (int i = 0; i < lvlButton.Length; i++)
        {
             Debug.Log("First "+i);
            if (i + firstLevelBuildIndex <= unlockedLvl)
            {
                int levelIndex = i + 1;
                Debug.Log("First in "+i);
                lvlButton[i].interactable = true;
                lvlButton[i].image.sprite = unlockedIcon;
                TextMeshProUGUI textButton = lvlButton[i].GetComponentInChildren<TextMeshProUGUI>();
                 lvlButton[i].onClick.AddListener(() => Navigator("Level " + levelIndex));
                textButton.text = (i + 1).ToString();
                textButton.enabled = true;
               
               
            }
            else
            {
                lvlButton[i].interactable = false;
                lvlButton[i].image.sprite = lockedIcon;
                lvlButton[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
    }

    void Navigator(string index)
    {
        Debug.Log(index);
        buttonController.LoadLevelString(index);
    }


}
