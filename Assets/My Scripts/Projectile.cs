using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    //[SerializeField] private GameObject damageIndicatorPrefab;
    private bool isActive;

    public void Initialize()
    {
        isActive = true;

        /* This method is for projectiles that have a parabole
         * We add a force only once, not every frame
         * Make sure to have "useGravity" toggle on in the rigidbody
         */
        projectileBody.AddForce(transform.forward * 700f + transform.up * 300f);
    }
    // Start is called before the first frame update
    void Update()
    {
        if (isActive)
        {
            /* This method is for projectiles that go in a straight line
             * We change the position every fram
             * Make sure to have "useGravity" toggled off in the rigidbody, otherwise it will fall as it flies (unless thats what you want)
             */

            /* Use either the following line (movement with the rigidbody)
             * projectileBody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
             */ 

            /* or this one (movement with the transform), both are ok
             * transform.Translate(transform.forward * speed * Time.deltaTime);
             */

            //projectileBody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
            //transform.Translate(transform.forward * speed * Time.deltaTime);
            // transform.forward is (0,0,1)
            // speed is 2f
            //
            //transform.Translate(transform.forward * speed * Time.fixedDeltaTime);
            transform.Translate(transform.forward * speed * Time.fixedDeltaTime);
            

            //projectileBody.AddForce((transform.forward + transform.up) * 50f * );
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;
        //GameObject damageIndicator = Instantiate(damageIndicatorPrefab);
        //damageIndicator.transform.position = collision.GetContact(0).point;
        DestructionFree destruction = collisionObject.GetComponent<DestructionFree>();
        //GameObject damageIndicator = Instantiate(damageIndicatorPrefab);
       // damageIndicator.transform.position = transform.position;
        Destroy(projectileBody);
    }
}
