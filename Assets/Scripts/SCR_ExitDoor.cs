using UnityEngine;
using UnityEngine.SceneManagement;
public class SCR_ExitDoor : MonoBehaviour
{
    public GameObject interactText;
    public SCR_PlayerMovement player;
    private bool interactable;
    private bool inRange;

    public AudioSource sound;

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
            sound.Play();
            SceneManager.LoadScene(3);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            print("Yay, you won!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && interactable && player.exitKey)
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
}
