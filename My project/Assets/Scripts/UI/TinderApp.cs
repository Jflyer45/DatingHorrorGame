using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TinderApp : MonoBehaviour
{
    public Image profilePicture;
    public Text name;
    public Text profileText;
    public Button rejectButton;
    public Button acceptButton;

    private int currentIndex = 0;
    private List<TinderProfile> profileLevels = new List<TinderProfile>();
    // Start is called before the first frame update
    void Start()
    {
        rejectButton.onClick.AddListener(delegate { ClickReject(); });
        acceptButton.onClick.AddListener(delegate { ClickAccept(); });

        // Will need at some point to populate this with only levels they
        // haven't completed yet. Could have data saved in JSON.
        TinderProfile test = new TinderProfile("Erik", "person", "Hello my name is erik", SceneLoaderUtils.Scene.Erik);
        profileLevels.Add(test);
        profileLevels.Add(new TinderProfile("Kevin", "person2",
            "Kebvin hart lol th some text", SceneLoaderUtils.Scene.Erik));

        SwitchProfile(profileLevels[currentIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ClickAccept()
    {
        SceneManager.LoadScene(profileLevels[currentIndex].scene);
        // Logic to remove profile? Probably not until completed level
    }

    private void ClickReject()
    {
        if (currentIndex == profileLevels.Count - 1)
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex++;
        }
        SwitchProfile(profileLevels[currentIndex]);
    }

    private void SwitchProfile(TinderProfile profile)
    {
        Debug.Log("Switching to " + profile.name);
        profilePicture.sprite = profile.profilePicture;
        profileText.text = profile.bio;
        name.text = profile.name;
    }
}
