using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;
using System.Data;
using UnityEngine.UI;
using TMPro;


public class CharacterControllerFINAL : MonoBehaviour
{

  
    [SerializeField] CinemachineVirtualCamera PlayerOneCamera;
    [SerializeField] CinemachineVirtualCamera PlayerTwoCamera;
    [SerializeField] private PlayerTurn playerTurn; 
    [SerializeField] private PlayerTurn playerTurn2;
    [SerializeField] public Vector3 jump;
    [SerializeField] public float jumpForce = 2.0f;
    [SerializeField] public int playerIndex;
    [SerializeField] private TextMeshProUGUI Ammo;
    
    public int ammo = 6;
    

    public float turnSpeed = 15;
    Camera mainCamera;
    Animator animator;
    Vector2 input;
    Rigidbody m_Rigidbody;
    public bool isGrounded;
    RaycastWeapon weapon;


    void Start()
    {
        FindObjectOfType<audioManager>().Play("Theme");
        FindObjectOfType<audioManager>().Play("Birds");

        animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        weapon = GetComponentInChildren<RaycastWeapon>();
    }

  
    void Update()
    {
        Ammo.text = Mathf.RoundToInt(ammo).ToString();
        

        if (playerTurn.IsPlayerTurn())
            {
                float yamCamera = mainCamera.transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yamCamera, 0), turnSpeed * Time.fixedDeltaTime);
                input.x = Input.GetAxis("Horizontal");
                input.y = Input.GetAxis("Vertical");

                animator.SetFloat("InputX", input.x);
                animator.SetFloat("InputY", input.y);

                if (Input.GetButtonDown("Fire1") && ammo > 0)
                {
                    weapon.StartFiring();
                    ammo--;
                    GetComponent<ActivePlayerWeapon>().ShootLaser();
                    FindObjectOfType<audioManager>().Play("Gun");
                }
                if (Input.GetButtonDown("Fire1") && ammo == 0)
                {
                    FindObjectOfType<audioManager>().Play("NoAmmo");
                }

                weapon.UpdateBullets(Time.deltaTime);
                if (Input.GetButtonUp("Fire1"))
                {
                    weapon.StopFiring();
                }
                if (Input.GetButtonDown("Fire2") && ammo == 0)
                {
                    FindObjectOfType<audioManager>().Play("Reload");
                    ammo = 6;
                }
                if (Input.GetKeyDown(KeyCode.KeypadEnter)) //&& IsTouchingFloor())
                {
                    ActivePlayerHealth activePlayerHealth = GetComponent<ActivePlayerHealth>();
                    activePlayerHealth.TakeDamage(20);
                }

                if (Input.GetKeyDown(KeyCode.Space)) //&& IsTouchingFloor())
                {
                    Jump();
                }
            }
        }

   
    private void Jump()
    {
        m_Rigidbody.AddForce(Vector3.up * 200f);
    }

    private bool IsTouchingFloor()
    {
        RaycastHit hit;

        bool result = Physics.SphereCast(transform.position, 0.35f, -transform.up, out hit, 1f);
        return result;
    }
    

    }
