using UnityEngine;
using UnityEngine.InputSystem;

public class SCR_NoteManager : MonoBehaviour
{

    public GameObject[] notes;

    public GameObject noteBoard;


    private void Start()
    {
        

        foreach (var note in notes)
        {

            note.SetActive(false);
        }

    }
    void Update()
    {
        
        if (Input.GetKey (KeyCode.Tab))
        {
            noteBoard.SetActive (true);

        }

        else
        {
            noteBoard.SetActive (false);
        }

    }



}
