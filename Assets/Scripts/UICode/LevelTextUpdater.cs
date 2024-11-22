using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTextUpdater : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI levelText; // Assign in Inspector

    private void Start()
    {
        if (levelText == null)
        {
            Debug.LogError("LevelTextUpdater: levelText is not assigned in the Inspector!");
            return;
        }

        // Get the current scene index to display the correct level
        UpdateLevelText();
    }

    public void UpdateLevelText()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex; // Get scene index
        levelText.text = $"Level {currentLevel}";
    }
}