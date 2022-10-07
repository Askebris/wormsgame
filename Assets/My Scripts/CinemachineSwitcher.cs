using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor;

public class CinemachineSwitcher : MonoBehaviour
{

    [SerializeField] private GameObject[] _vCams = new GameObject[1];

    [SerializeField] private int[] _vCamsID = new int[] {0, 1};

    void Start()
    {
        
    }

    void Update()
    {
            for (int i = 0; i < _vCams.Length; i++)
            {
                Debug.Log(_vCams[i]);
                Debug.Log(_vCamsID[i]);

            
        }
        }
    public void SwitchCamera()
    {
        for (int i = 0; i < _vCams.Length; i++)
        {
            Debug.Log(_vCams[i]);
            Debug.Log(_vCamsID[i]);

            _vCams[i].SetActive(false);
        }
    }
    }


