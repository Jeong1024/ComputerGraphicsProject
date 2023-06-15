using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TextChanger : MonoBehaviour
{
    public Text targetText; // ��ȭ��ų �ؽ�Ʈ ������Ʈ
    public string[] texts = { "���� ���θ� �ϰ� ���� ���ư��� ��, ���ڱ� �� ���� �ִ� ������ȭ���� ���Ҹ��� ����Դ�.", 
        "���� �ƹ� ���� ���� ��ȭ�� �޾Ұ�, ��ȭ ���� ��Ҹ��� ���� '�� ���а��� ���� ������ ã�� �� �ִ�'�� ���ߴ�.", 
        "�� ���� ��� ���� �ִ� â���� ���� ������ ������, �̳� â���� ������ ���Ҵ�.",
    "���⼭ �����߸� �Ѵ�."}; // ��ȭ�� ���ڵ��� �迭
    public float changeInterval = 3f; // ��ȭ ���� (��)

    private float timer = 0f;
    private int currentIndex = 0;

    private void Start()
    {
        if (targetText == null)
        {
            Debug.LogError("TextChanger: Target Text component is not assigned!");
            return;
        }

        // ù��° ���ڷ� �ʱ�ȭ
        targetText.text = texts[currentIndex];
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (currentIndex == texts.Length - 1)
            changeInterval *= 2;

        // ���� ���ݸ��� ���� ����
        if (timer >= changeInterval)
        {
            currentIndex = (currentIndex + 1) % texts.Length; // ���� �ε��� ��� (�迭 ������ ����� ó������ ���ư�)
            targetText.text = texts[currentIndex]; // ���� ����
            timer = 0f; // Ÿ�̸� �ʱ�ȭ

            if(currentIndex==texts.Length-1)
            {
                SceneManager.LoadScene("InGameScene");

            }
        }
        
    }
}
