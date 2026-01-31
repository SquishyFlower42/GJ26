using UnityEngine;
using UnityEngine.UI;
public class SCR_Lock : MonoBehaviour
{

    public GameObject lockCanvas;
    public Text[] lockText;

    public string password;
    public string[] lockCharacterChoices;
    public int[] lockCharacterNumber;
    private string insertedPassword;

    public GameObject interactText;
    public SCR_PlayerMovement player;
    private bool interactable;
    private bool inRange;

    public Camera playerCam;
    public Camera puzzleCam;

    public GameObject objCombination;
    private bool firstTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lockCharacterNumber = new int[password.Length];
        UpdateUI();
        interactable = true;
        inRange = false;
        firstTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(player.interactKey) && interactable && inRange)
        {
            StartDecoding();

            if (firstTime) { objCombination.SetActive(true); firstTime = false; }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && interactable)
        {
            interactText.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && interactable)
        {
            interactText.SetActive(false);
            inRange = false;
        }
    }

    public void IncreaseInsertedPassword(int number)
    {
        lockCharacterNumber[number]++;
        if (lockCharacterNumber[number] >= lockCharacterChoices[number].Length)
        {
            lockCharacterNumber[number] = 1;
        }

        
        UpdateUI();
    }

    public void DecreaseInsertedPassword(int number)
    {
        lockCharacterNumber[number]--;
        if (lockCharacterNumber[number] <= 0)
        {
            lockCharacterNumber[number] = 9;
        }

        
        UpdateUI();
    }

    public void CheckPassword()
    {

        int pass_len = password.Length;
        insertedPassword = "";
        for (int i=0;i<pass_len;i++)
        {
            insertedPassword += lockCharacterChoices[i][lockCharacterNumber[i]].ToString();
        }
        if (password == insertedPassword)
        {
            Unlock();
        }


    }

    public void Unlock()
    {

        player.lockOpened = true;
        interactable = false;
        StopDecoding();
        objCombination.SetActive(false);

    }

    public void UpdateUI()
    {
        int len = lockText.Length;
        for (int i=0; i<len;i++)
        {
            lockText[i].text = lockCharacterChoices[i][lockCharacterNumber[i]].ToString();
        }
    }

    public void StartDecoding()
    {

        if (interactable)
        {
            interactText.SetActive(false);
            puzzleCam.enabled = true;
            playerCam.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            lockCanvas.SetActive(true);
        }

    }

    public void StopDecoding()
    {
        interactText.SetActive(false);
        puzzleCam.enabled = false;
        playerCam.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        lockCanvas.SetActive(false);
    }


}
