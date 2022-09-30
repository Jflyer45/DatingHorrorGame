using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderUtils : MonoBehaviour
{
    public class Scene
    {
        public const int MainMenu = 0;
        public const int Room = 1;
        public const int Erik = 2;
    }

    public static void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
