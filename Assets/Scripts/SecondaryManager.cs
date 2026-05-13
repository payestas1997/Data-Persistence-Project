using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SecondaryManager : MonoBehaviour
{
    public static SecondaryManager secondarymanager;
    public InputField inputField;
    public Text Text;
    public string playerText;
    public int m_HighScore;
    public string m_HighScorePlayer;


    private void Awake()
    {
        if (secondarymanager == null)
        {
            secondarymanager = this;
            DontDestroyOnLoad(gameObject);
            LoadPoints();
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

 
    public void SetPlayerName()
    {
        playerText = inputField.text;

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    [System.Serializable]   
    public class SaveData
    {
        public int highscore;
        public string highscoreplayer;
    }

  
    public void LoadPoints()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            m_HighScore = data.highscore;
            m_HighScorePlayer = data.highscoreplayer;

            Text.text =  "Best Score: " + m_HighScorePlayer + ": " + m_HighScore;
        }
    }
}
        
