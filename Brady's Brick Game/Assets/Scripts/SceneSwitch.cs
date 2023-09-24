
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void OnSceneSwitch()
    {
        SceneManager.LoadScene("GameScene");
    }
}
