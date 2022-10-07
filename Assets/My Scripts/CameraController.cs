using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private PlayerTurn playerTurn2;

    public GameObject target;
    public GameObject target2;
    public float xOffset, yOffset, zOffset;
    // Update is called once per frame
    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {
            transform.position = target.transform.position + new Vector3(xOffset, yOffset, zOffset);
            transform.LookAt(target.transform.position);
        }
        else if (playerTurn2.IsPlayerTurn())
        {
            transform.position = target2.transform.position + new Vector3(xOffset, yOffset, zOffset);
            transform.LookAt(target2.transform.position);
        }
    }
}
