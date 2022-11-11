using UnityEngine;
using TMPro;
public class PlayerProfileUI : MonoBehaviour
{
    public PlayerProfile profileSingleton;

    public TMP_InputField nameBox;
    public TMP_Dropdown favColorBox;
    public TMP_Dropdown getAwayBox;
    public void ChangePlayerName()
    {
        Debug.Log("Changing name: " + nameBox.text);
        //PlayerPrefs.SetString("name", nameBox.text); example
        profileSingleton.playerName = nameBox.text;
    }
    public void ChangeFavColor()
    {
        profileSingleton.favColor = favColorBox.itemText.text;
    }
    public void ChangeGetAway()
    {
        profileSingleton.getAway = getAwayBox.itemText.text;
    }

    public void SumbitButton()
    {
        SceneLoaderUtils.ChangeScene(SceneLoaderUtils.Scene.Room);
    }
}
