using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGenerate : MonoBehaviour
{
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private Sprite unlockIcon;
    [SerializeField] private Sprite lockIcon;
    [SerializeField] private int firstLevelBuildIndex;
    [SerializeField] private GridLayoutGroup buttonGroup;
    ButtonController buttonController = new ButtonController();

    private void Awake()
    {
        int unlockedLvl = PlayerPrefs.GetInt("LevelUnlock", firstLevelBuildIndex);
        int sceneCount = UnityEditor.SceneManagement.EditorSceneManager.sceneCountInBuildSettings - firstLevelBuildIndex;

        for (int i = 0; i < sceneCount; i++)
        {
            Button button = Instantiate(buttonPrefab, Vector2.zero, Quaternion.identity);
            button.transform.SetParent(buttonGroup.transform, false);
            int levelIndex = i + 1;
            if (i + firstLevelBuildIndex <= unlockedLvl)
            {
                button.interactable = true;
                button.image.sprite = unlockIcon;
                TextMeshProUGUI textButton = button.GetComponentInChildren<TextMeshProUGUI>();
                textButton.text = levelIndex.ToString();
                textButton.enabled = true;
                button.onClick.AddListener(() => Navigator("Level " + levelIndex));
            }
            else
            {
                button.interactable = false;
                button.image.sprite = lockIcon;
                button.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
    }

    void Navigator(string index)
    {
        Debug.Log(index);
        buttonController.LoadLevelString(index);
    }
}
