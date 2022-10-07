using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    private int playerindex;

    public void SetPlayerTurn(int index)
    {
        playerindex = index;
    }

    public bool IsPlayerTurn()
    {
        return TurnManager.GetInstance().IsItPlayerTurn(playerindex);
    }
}
