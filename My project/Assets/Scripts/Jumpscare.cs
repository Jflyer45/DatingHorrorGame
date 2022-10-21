using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jumpscare : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource AS;
    private Navigation navigation;
    [SerializeField] private GameManager GM;
    [SerializeField] private FPSController fps;
    public Image image;
    public MusicController MC;

    private void Awake()
    {
        navigation = GetComponent<Navigation>();
        image.enabled = false;
        AS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(GM.jumpscareActive);
        if (GM.jumpscareActive && other.tag == "Player")
        {
            MC.PauseMusic();
            AS.Play();
            fps.canMove = false;
            navigation.StopMoving();
            // Becuase it's created at run time it's the only way to grab it.
            GameObject.Find("DateNPC/UMARenderer").SetActive(false);
            EnableUI();
            StartCoroutine(SwitchScenes());
        }
    }

    private void EnableUI()
    {
        image.enabled = true;
    }

    IEnumerator SwitchScenes()
    {
        yield return new WaitForSeconds(2);
        SceneLoaderUtils.ChangeScene(SceneLoaderUtils.Scene.Erik);
    }
}
