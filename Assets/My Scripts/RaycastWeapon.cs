using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    
    class Bullet
    {
        public float time;
        public Vector3 initialPosition;
        public Vector3 initialVelocity;
        public TrailRenderer tracer;
    }
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private PlayerTurn playerTurn2;
    public float damage;
    public bool isFiring = false;
    public float bulletSpeed = 1000.0f;
    public float bulletDrop = 0.0f;
    public ParticleSystem muzzleFlash;
    public ParticleSystem hitEffect;
    public ParticleSystem bloodEffect;
    public TrailRenderer tracerEffect;
    public Transform raycastOrigin;
    public Transform raycastDestination;
    [SerializeField] private PlayerTurn playerturn;


    Ray ray;
    RaycastHit hitInfo;
    List<Bullet> bullets = new List<Bullet>();
    float maxLifetime = 3.0f;

    Vector3 GetPosition(Bullet bullet)
    {
        // p + v*t + 0.5*g*t*t
        Vector3 gravity = Vector3.down * bulletDrop;
        return (bullet.initialPosition) + (bullet.initialVelocity * bullet.time) + (0.5f * gravity * bullet.time * bullet.time);
    }

    Bullet CreateBullet(Vector3 position, Vector3 velocity)
    {
        Bullet bullet = new Bullet();
        bullet.initialPosition = position;
        bullet.initialVelocity = velocity;
        bullet.time = 0.0f;
        bullet.tracer = Instantiate(tracerEffect, position, Quaternion.identity);
        bullet.tracer.AddPosition(position);
        return bullet;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name != "Player")
        {
            if(collisionGameObject.GetComponent<ActivePlayerHealth>() != null)
            {
                collisionGameObject.GetComponent<ActivePlayerHealth>().TakeDamage(20);
            }
        }    
    }

    private void Update()
    {

        bool IsPlayerTurn = playerturn.IsPlayerTurn();

        //if (Input.GetButtonDown("C"))
        //{
          //  if (IsPlayerTurn)
            //{
                
               // GameObject newProjectile = Instantiate(projectilePrefab);
               // newProjectile.transform.position = shootingStartPosition.position;
               // newProjectile.transform.forward = shootingStartPosition.position;
               // newProjectile.GetComponent<Projectile>().Initialize();
          //      TurnManager.GetInstance().TriggerChangeTurn();
            //}
        //}
    }
    public void StartFiring()
    {
        if (playerTurn.IsPlayerTurn())
        {
            isFiring = true;
            muzzleFlash.Emit(1);

            Vector3 velocity = (raycastDestination.position - raycastOrigin.position).normalized * bulletSpeed;
            var bullet = CreateBullet(raycastOrigin.position, velocity);
            bullets.Add(bullet);
            
        }
    }

    public void UpdateBullets(float deltaTime)
    {
        SimulateBullets(deltaTime);
        DestroyBullets();
    }

    void SimulateBullets(float deltaTime)
    {
        bullets.ForEach(bullet =>
            {
                Vector3 p0 = GetPosition(bullet);
                bullet.time += deltaTime;
                Vector3 p1 = GetPosition(bullet);
                RaycastSegment(p0, p1, bullet);
            });
    }

    void DestroyBullets()
    {
        bullets.RemoveAll(bullet => bullet.time >= maxLifetime);
    }

    void RaycastSegment(Vector3 start, Vector3 end, Bullet bullet)
    {
        Vector3 direction = end - start;
        float distance = direction.magnitude;
        ray.origin = start;
        ray.direction = direction;
        if (Physics.Raycast(ray, out hitInfo))
        {
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);

            bullet.tracer.transform.position = hitInfo.point;
            bullet.time = maxLifetime;
            
        }
        else
        {
            bullet.tracer.transform.position = end;
        }
    }

    public void StopFiring()
    {
        if (playerTurn.IsPlayerTurn())
        {
            isFiring = false;
        }
    }
}
