using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisions : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Rigidbody characterBody;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        characterBody.AddForce(Vector3.down * 100f);
        //meshRenderer.material.color = GetRandomColor();
    }

    private void OnCollisionExit(Collision collision)
    {
        //meshRenderer.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        Color color = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f), 1f);
        return color;
    }
}
