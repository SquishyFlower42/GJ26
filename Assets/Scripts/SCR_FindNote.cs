using UnityEditor.UI;
using UnityEngine;

public class SCR_FindNote : MonoBehaviour
{


    public SCR_NoteManager noteManager;
    
    public int noteNumber;

    public GameObject self;

    public GameObject noteUI;
    public GameObject noteKeybindUI;

    public GameObject interactText;
    public SCR_PlayerMovement player;
    private bool interactable;
    private bool inRange;


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
            FindNote();
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

    public void FindNote()
    {
        interactable = false;
        interactText.SetActive(false);
        noteManager.notes[noteNumber].SetActive(true);
        noteKeybindUI.SetActive(true);
        noteUI.SetActive(true);
    }

}
