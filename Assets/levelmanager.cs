using TMPro;
using UnityEngine;

public class levelmanager : MonoBehaviour
{
    public TMP_FontAsset newFont; // Assign the new font in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        ChangeAllFonts();
    }

    void ChangeAllFonts()
    {
        // Find all root GameObjects in the scene
        GameObject[] rootGameObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

        // Iterate through all root GameObjects
        foreach (GameObject rootGameObject in rootGameObjects)
        {
            // Call the recursive function to search and change fonts for TextMeshProUGUI components in the GameObject and its children
            ChangeFontInChildren(rootGameObject);
        }
    }

    void ChangeFontInChildren(GameObject parent)
    {
        // Get the TextMeshProUGUI component from the GameObject, if it has one
        TextMeshProUGUI textComponent = parent.GetComponent<TextMeshProUGUI>();

        // If a TextMeshProUGUI component is found, change its font
        if (textComponent != null)
        {
            textComponent.font = newFont;
        }

        // Iterate through all child GameObjects
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            // Recursively call this function for each child GameObject
            ChangeFontInChildren(child);
        }
    }


}
