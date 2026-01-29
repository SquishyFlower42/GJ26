using UnityEngine;
using UnityEngine.UI;
public class SCR_Lock : MonoBehaviour
{

    public bool interactable = true;
    public GameObject lockCanvas;
    public Text[] lockText;

    public string password;
    public string[] lockCharacterChoices;
    public int[] lockCharacterNumber;
    private string insertedPassword;


    void Start()
    {
        lockCharacterNumber = new int[password.Length];
        UpdateUI();
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
        interactable = false;
        StopDecoding();
        gameObject.SetActive(false);
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
            lockCanvas.SetActive(true);
    }

    public void StopDecoding()
    {
        lockCanvas.SetActive(false);
    }


}
