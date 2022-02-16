/* @author Ralph Burton */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI text;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        // Show the panel that holds the loading bar
        loadingScreen.SetActive(true);

        // Intentional pause to display the coroutine working
        yield return new WaitForSeconds(.5f);

        // Assign the variable to the operation so that the variables within it
        // can be show (ex: operation.progress)
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        // Update the loading bar values
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            text.text = progress * 100 + "%";
            yield return null;
        }
    }
}
