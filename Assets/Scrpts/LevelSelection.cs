using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LevelSelection : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonContainer;
    public int totalLevels = 10;

    void Start()
    {
        for (int i = 1; i <= totalLevels; i++)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, buttonContainer);
            Button levelButton = buttonObj.GetComponent<Button>();
            TMP_Text buttonText = buttonObj.GetComponentInChildren<TMP_Text>();

            buttonText.text = i.ToString();
            bool isUnlocked = PlayerPrefs.GetInt("Level" + i, i == 1 ? 1 : 0) == 1;
            levelButton.interactable = isUnlocked;

            if (isUnlocked)
            {
                buttonText.gameObject.SetActive(true);
                int levelIndex = i;
                levelButton.onClick.AddListener(() => SelectLevel(levelIndex));
            }
            else
            {
                buttonText.gameObject.SetActive( false);
            }
        }
    }

    void SelectLevel(int level)
    {
        PlayerPrefs.SetInt("LastLevel", level);
        SceneManager.LoadScene("SampleScene");
    }

}
