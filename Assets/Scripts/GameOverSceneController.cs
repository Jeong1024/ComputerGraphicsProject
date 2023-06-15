using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneController : MonoBehaviour
{
    public Text gameOverText;
    public Button returnButton;
    public Button exitButton;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // �ʱ�ȭ
        //gameOverText.gameObject.SetActive(false);

        // ���ư��� ��ư Ŭ�� �̺�Ʈ
        returnButton.onClick.AddListener(ReturnToGame);

        // ���� ��ư Ŭ�� �̺�Ʈ
        exitButton.onClick.AddListener(ExitGame);
    }

    private void ReturnToGame()
    {
        SceneManager.LoadScene("InGameScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
