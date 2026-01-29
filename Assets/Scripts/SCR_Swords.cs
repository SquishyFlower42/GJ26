using UnityEngine;

public class SCR_Swords : MonoBehaviour
{

    public GameObject swordOne;
    public GameObject swordTwo;
    public GameObject swordThree;
    public GameObject swordFour;
    
    public GameObject[] swordCorrectPositions;

    public GameObject posOne;
    public GameObject posTwo;
    public GameObject posThree;
    public GameObject posFour;

    public SCR_SwapSword[] swapSword;
    
    
    public bool interactable = true;

    public int correctCount = 0;
    public string swordPositions;
    public string solution;

    public GameObject swordCanvas;






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
            swordCanvas.SetActive(true);
        }
        

    }

    public void PuzzleStop()
    {

        swordCanvas.SetActive(false);

    }

    public void PuzzleWin()
    {

        //Drawer opens and key is found. A noise is made to alert the player of where the key is!
        interactable = false;
        PuzzleStop();


    }

}
