using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadScene("Main");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadScene("Demo");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LoadScene("Training");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApplication() => Application.Quit();
}
