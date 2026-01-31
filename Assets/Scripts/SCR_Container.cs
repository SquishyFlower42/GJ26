using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SCR_Container : MonoBehaviour
{
    public GameObject interactText;
    public SCR_PlayerMovement player;
    public GameObject lid;
    public GameObject[] maskIcon;
    public AudioSource audioOpen;
    public AudioSource audioClose;
    private bool interactable;
    private bool inRange;

    private Vector3 moveEnd;
    private Vector3 moveStart;
    private Vector3 moveTowards;
    public float moveSpeed = 0.3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = true;
        inRange = false;
        moveStart = lid.transform.position;
        moveTowards = moveStart;
        moveEnd = lid.transform.position;
        moveEnd.y = lid.transform.position.y + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(player.interactKey) && interactable && inRange)
        {
            audioOpen.Play();
            interactable = false;
            moveTowards = moveEnd;
            interactText.SetActive(false);
            player.mask = true;
            foreach (var item in maskIcon)
            {
                item.SetActive(true);
            }
            foreach (var effect in player.activeEffects)
            {
                effect.gameObject.SetActive(true);
            }
        }

        if (lid.transform.position != moveTowards)
        {
            lid.transform.position = Vector3.MoveTowards(lid.transform.position, moveTowards, Vector3.Distance(transform.position, moveTowards) * moveSpeed * Time.deltaTime);
        }

        if (lid.transform.position == moveEnd)
        {
            audioClose.Play();
            moveTowards = moveStart;
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
}
