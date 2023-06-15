
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorScript : MonoBehaviour
{
    public bool open = false;
    public bool needpassword = false;
    public float doorOpenAngle = -90f;
    public float doorCloseAngle = 0f;
    public float smooth = 2f;
    public GameObject keyObject;
    public GameObject message;
    public GameObject passwordScreen;
    public TMP_InputField inputPassword;
    AudioSource audioSource;

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.localRotation;
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleDoorState()
    {
        open = !open;
    }

    void messageOff()
    {
        message.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (CanInteract())
        {
            ToggleDoorState();
            audioSource.Play();
        }
        else if (message != null)
        {
            message.SetActive(true);
            Invoke("messageOff", 2f);
        }
    }

    public bool CanInteract()
    {
        if (keyObject != null && keyObject.activeSelf == false && !needpassword)
        {
            return false;
        }
        else if (needpassword)
        {
            if (keyObject.activeSelf == true)
            {
                return true;
            }
            if (keyObject.activeSelf == false)
            {
                passwordScreen.SetActive(true);
                inputPassword.ActivateInputField();
                inputPassword.Select();
                return false;
            }
            return true;
        }
        else
            return true; // ��ȣ�ۿ� ���� ���ο� ���� �߰� ������ �����Ϸ��� ������ ���⿡ �߰��ϼ���.
    }

    void Update()
    {
        Quaternion targetRotation;

        if (open)
        {
            targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
        }
        else
        {
            targetRotation = Quaternion.Euler(0, doorCloseAngle, 0);
        }

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}
