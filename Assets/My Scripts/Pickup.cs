using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    private CharacterControllerFINAL characterController;

    private void Awake()
    {
        characterController = FindObjectOfType<CharacterControllerFINAL>();
    }

    private void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider col)
    {

        FindObjectOfType<audioManager>().Play("Reload");
        characterController.ammo = 6;
        Destroy(gameObject);
    }
}
