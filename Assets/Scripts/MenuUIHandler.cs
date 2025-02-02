using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI tmpHighScore;
    public static string sPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmpHighScore.text = "High Score: " + DataManager.instance.iHighScore + " - " + DataManager.instance.sPlayerH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerNameUpdate(string sName)
    {
        sPlayer = sName;
        Debug.Log(sPlayer);

    }
    public void StartNew()
    {
        DataManager.instance.sPlayerC = sPlayer;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        DataManager.instance.SaveData();
    }
}
