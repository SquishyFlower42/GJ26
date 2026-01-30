using UnityEngine;
using UnityEngine.UI;
public class SCR_Buttonpuzzle : MonoBehaviour
{

    public int numberOfButtons;
    public int correctButtons;

    public SCR_ButtonPress[] buttonPresses;
    public GameObject[] buttons;
    public GameObject[] movedButtons;
    public GameObject[] moveButtonPos;

    public GameObject buttonCanvas;

    public GameObject interactText;
    public SCR_PlayerMovement player;
    private bool interactable;
    private bool inRange;

    public Camera playerCam;
    public Camera puzzleCam;

    public GameObject closedChest;
    public GameObject openChest;
    public GameObject exitKey;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = true;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(player.interactKey) && interactable && inRange)
        {
            BeginPuzzle();
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


    public void CheckForWin()
    {



        if (correctButtons == 6)
        {
            WinPuzzle();
        }
        else
        {
            correctButtons = 0;
            numberOfButtons = 0;
            foreach (var button in buttonPresses)
            {
                button.pressed = false;
                button.wasCorrect = false;
            }
            foreach (var button in buttons)
            {
                button.SetActive(true);
            }

            foreach (var button in movedButtons)
            {

                for (int i = 0; i <= 5; i++)
                {

                    movedButtons[i].transform.position = moveButtonPos[i].transform.position;

                }

            }
        }


    }



    public void BeginPuzzle()
    {
        if (interactable)
        {
            interactText.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            puzzleCam.enabled = true;
            playerCam.enabled = false;

            buttonCanvas.SetActive(true);
        }
        

    }

    public void EndPuzzle()
    {
        interactText.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        puzzleCam.enabled = false;
        playerCam.enabled = true;

        buttonCanvas.SetActive(false);



    }


    public void WinPuzzle()
    {

        // play a sound from the drawer that opens with the key to let the player know that something has happened. 
        puzzleCam.enabled = false;
        playerCam.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        interactable = false;
        buttonCanvas.SetActive(false);
        interactText.SetActive(false);

        closedChest.SetActive(false);
        openChest.SetActive(true);
        exitKey.SetActive(true);
    }



}
