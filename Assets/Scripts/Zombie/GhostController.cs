
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GhostController : MonoBehaviour
{
    public Transform[] patrolPoints; // ���� �������� ��ġ ������ ��� �迭
    public float patrolSpeed = 3f; // ���� �ӵ�
    public float detectionRange = 1f; // �÷��̾� ���� ����

    private Transform player; // �÷��̾��� ��ġ ����
    private int currentPatrolIndex = 0; // ���� ���� ������ �ε���
    private bool isChasing = false; // �߰� �������� ����

    //public UnityEngine.UI.Image gameOverImage; //���ӿ��� �̹���
    
    //public UnityEngine.UI.Text gameOverText; // ���� ���� �ؽ�Ʈ

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //GameManager.Instance.SetGameOverText(gameOverText);

        //gameOverText = GameObject.Find("GameOverText").GetComponent<UnityEngine.UI.Text>(); // ������ �κ�

        //gameOverImage.sprite = Resources.Load<Sprite>("GameOverImage");

        //gameOverImage.gameObject.SetActive(false); //���ӿ��� �̹��� ��Ȱ��ȭ
        //gameOverText.gameObject.SetActive(false); // ���� ���� �ؽ�Ʈ ��Ȱ��ȭ

    }

    private void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
            CheckDetection();
        }
    }

    private void Patrol()
    {
        Vector3 targetPosition = patrolPoints[currentPatrolIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            if (currentPatrolIndex == 0 || currentPatrolIndex == patrolPoints.Length - 1)
            {
                // �糡 ������ �����ϸ� 180�� ȸ��
                transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }

    private void CheckDetection()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            Debug.Log("Player detected! Game over.");
            // ���� ���� ó�� ���� �߰�
            GameOver();

        }
    }

    private void ChasePlayer()
    {
        // �÷��̾ �߰��ϴ� ���� ����
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾�� �浹���� �� ���� ���� ó��
            GameOver();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �÷��̾�� �浹���� �� ���� ���� ó��
            GameOver();
        }
    }
    private void GameOver()
    {
        Debug.Log("Game Over!");
        // ���� ���� ó�� ������ ���⿡ �߰��ϼ���.
        //gameOverText.gameObject.SetActive(true);

        //gameOverImage.gameObject.SetActive(true);
        //GameManager.Instance.GameOver(gameOverText);

        //GameManager.Instance.GameOver();

        SceneManager.LoadScene("GameOverScene"); // GameOverScene���� ��ȯ

        //GameManager.Instance.SetGameOverText(gameOverText.text); // GameOverText ����
        // ȭ�� ��⸦ �����ϴ� �ڵ� �߰�
        RenderSettings.ambientIntensity = 0.2f; // ȯ�� ������ ������ ����ϴ�.
        RenderSettings.reflectionIntensity = 0.2f; // �ݻ� ������ ����ϴ�.

    }

    // ��Ÿ �ʿ��� �Լ� �� �ڵ� �߰� ����
}
