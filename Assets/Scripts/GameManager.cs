/*using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject managerObject = new GameObject("GameManager");
                    instance = managerObject.AddComponent<GameManager>();
                    DontDestroyOnLoad(managerObject);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void GameOver()
    {
        // ���� ���� �� ���� ���� ������ ��ȯ�ϴ� ���� �߰�
        SceneManager.LoadScene("GameOverScene");
    }

    public void PlayAgain()
    {
        // �����ϱ� ��ư�� ������ �� ȣ��Ǵ� �Լ�
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        // ���� ��ư�� ������ �� ȣ��Ǵ� �Լ�
        Application.Quit();
    }
}
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    // �̱��� ���� ����
    private static GameManager _instance;
    //public static GameManager Instance { get { return _instance; } }
    //public static GameManager Instance { get; private set; }
    public static GameManager Instance;
   
    public Text gameOverText;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ...
    /*
    public void GameOver(string text)
    {
        Debug.Log("Game Over!");
        // ���� ���� ó�� ������ ���⿡ �߰��ϼ���.
        gameOverText.text = text;
        //gameOverText.gameObject.SetActive(true);

        // ���ӿ��� �� ���� ���� ������ ��ȯ
        SceneManager.LoadScene("GameOverScene");

        // ȭ�� ��⸦ �����ϴ� �ڵ� �߰�
        RenderSettings.ambientIntensity = 0.2f; // ȯ�� ������ ������ ����ϴ�.
        RenderSettings.reflectionIntensity = 0.2f; // �ݻ� ������ ����ϴ�.
    }*/
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    /*
    public void PlayAgain()
    {
        // �����ϱ� ��ư�� ������ �� ȣ��Ǵ� �Լ�
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        // ���� ��ư�� ������ �� ȣ��Ǵ� �Լ�
        Application.Quit();
    }*/
    /*public void SetGameOverText(String text)
    {
        gameOverText.text = text;
    }
    public Text GetGameOverText()
    {
        return gameOverText;
    }*/

    // ...
}
