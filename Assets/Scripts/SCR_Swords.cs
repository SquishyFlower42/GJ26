using UnityEngine;

public class SCR_Swords : MonoBehaviour
{

    public GameObject[] swordCorrectPositions;

    public GameObject posOne;
    public GameObject posTwo;
    public GameObject posThree;
    public GameObject posFour;

    public SCR_SwapSword[] swapSword;
    

    public int correctCount = 0;


    public Camera playerCam;
    public Camera puzzleCam;

    public GameObject swordCanvas;

    public GameObject interactText;
    public SCR_PlayerMovement player;
    private bool interactable;
    private bool inRange;


    public SCR_NoteManager noteManager;

    public int firstNote;
    public int secondNote;

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
            PuzzleBegin();
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

    public void CheckSolution()
    {

        for (int i = 0; i <= 3; i++)
        {

            if (swapSword[i].currentSword == swordCorrectPositions[i])
            {
                correctCount++;
            }

        }

        Debug.Log(correctCount);

        if (correctCount == 4)
        {
            PuzzleWin();
        }

        else
        {
            correctCount = 0;
        }

    }

    public void PuzzleBegin()
    {
        if (interactable)
        {
            interactText.SetActive(false);
            puzzleCam.enabled = true;
            playerCam.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            swordCanvas.SetActive(true);
        }
        

    }

    public void PuzzleStop()
    {
        interactText.SetActive(false);
        puzzleCam.enabled = false;
        playerCam.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        swordCanvas.SetActive(false);

    }

    public void PuzzleWin()
    {

        noteManager.notes[5].SetActive(true);
        noteManager.notes[6].SetActive(true);
        noteManager.notes[4].SetActive(true);
        noteManager.notes[3].SetActive(true);

        interactText.SetActive(false);
        puzzleCam.enabled = false;
        playerCam.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        interactable = false;
        swordCanvas.SetActive(false);


    }

}
