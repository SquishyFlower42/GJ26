using UnityEngine;
using UnityEngine.UI;
public class SCR_ButtonPress : MonoBehaviour
{

    public SCR_Buttonpuzzle buttonPuzzle;

    public SCR_ButtonPress previousButton;

    public GameObject button;
    public GameObject movedButton;
    public GameObject movePos;


    public bool pressed = false;
    public bool wasCorrect = false;
    public bool correctFirst = false;

    public int correctTime;

    public void PressButton()
    {
        buttonPuzzle.numberOfButtons++;
        movedButton.transform.position = movePos.transform.position;

        if (pressed == false && correctTime == buttonPuzzle.numberOfButtons)
        {
            pressed = true;
            buttonPuzzle.correctButtons++;


            button.SetActive(false);


            if (buttonPuzzle.numberOfButtons == 6)
            {
                buttonPuzzle.CheckForWin();
            }
            
        }
        else
        {
            pressed = true;
            button.SetActive(false);

            if (buttonPuzzle.numberOfButtons == 6)
            {
                buttonPuzzle.CheckForWin();
            }
        }

        

    }


}
