using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] _vCams = new GameObject[1];

    [SerializeField] private int[] _vCamsID = new int[] { 0, 1 };
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private PlayerTurn playerTurn2;

    public GameObject target;
    public GameObject target2;
    
    // Update is called once per frame
    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {
            for (int i = 0; i < _vCams.Length; i++)
            {
                Debug.Log(_vCams[i]);
                Debug.Log(_vCamsID[i]);

                _vCams[0].SetActive(true);
            }
        }
        else if (playerTurn2.IsPlayerTurn())
        {
            SwitchCamera();
        }
    }
    public void SwitchCamera()
    {
        for (int i = 0; i < _vCams.Length; i++)
        {
            Debug.Log(_vCams[i]);
            Debug.Log(_vCamsID[i]);

            _vCams[0].SetActive(false);
        }
    }
}
