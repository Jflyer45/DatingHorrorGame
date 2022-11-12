using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("change");
    }

    private IEnumerator change()
    {
        yield return new WaitForSeconds(10);
        SceneLoaderUtils.ChangeScene(SceneLoaderUtils.Scene.Room);
    }
}
