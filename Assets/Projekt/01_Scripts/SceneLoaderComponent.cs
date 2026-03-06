using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderComponent : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
        
    }

}
