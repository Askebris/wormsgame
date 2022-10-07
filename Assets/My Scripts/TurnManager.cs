using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private float maxTimePerTurn;
    [SerializeField] private Image clock;
    [SerializeField] private TextMeshProUGUI seconds;

    private int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;
    private float currentTurnTime = 20;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);
        }
    }

    private void Update()
    {
        
        {
            seconds.text = Mathf.RoundToInt(currentTurnTime).ToString();
            currentTurnTime -= Time.deltaTime;
            clock.fillAmount = 1 - (currentTurnTime / maxTimePerTurn);
            

            if (currentTurnTime <= 0)
            {
                TriggerChangeTurn();
                currentTurnTime = 20;
            }
            if (waitingForNextTurn)
            {
                turnDelay += Time.deltaTime;
                if (turnDelay >= timeBetweenTurns)
                {
                    turnDelay = 0;
                    waitingForNextTurn = false;
                    ChangeTurn();
                }
            }
        }
        
    }

    

    public bool IsItPlayerTurn(int index)
    {
        if(waitingForNextTurn)
        {
            return false;
        }

        return index == currentPlayerIndex;

    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn=true;
    }

    public void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
        }
    }

}
