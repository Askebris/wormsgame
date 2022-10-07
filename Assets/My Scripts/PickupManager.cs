using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupManager : MonoBehaviour
{
    private static PickupManager instance;
    [SerializeField] GameObject pickupPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static PickupManager GetInstance()
    {
        return instance;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            GameObject newPickup = Instantiate(pickupPrefab);
            newPickup.transform.position = new Vector3 (Random.Range(0f, 5f), 1f, Random.Range(0f, 5f));
        }
    }
}
