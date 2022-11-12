using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderUtils : MonoBehaviour
{
    public class Scene
    {
        public const int MainMenu = 0;
        public const int Room = 1;
        public const int Erik = 2;
        public const int Bowling = 3;
        public const int HorrorBasement = 4;
        public const int Win = 5;
    }

    public static void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
