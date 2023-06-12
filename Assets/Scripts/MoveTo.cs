// MoveTo.cs
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public Transform goal;
    public NavMeshAgent enemigo;
    public bool perseguir;
    public Animator controlEnemigo;

    public UI_control script;

    private bool isDead = false;
    
    void Start()
    {
        enemigo = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (perseguir)
        {
            enemigo.destination = goal.position;
            controlEnemigo.SetBool("persigue", true);
        }
        else
        {
            enemigo.destination = this.transform.position;
            controlEnemigo.SetBool("persigue", false);
        }
    
    }

    public void CollisionWithPlayer()
    {
       
        controlEnemigo.SetBool("attack", true);
        perseguir = false;
    }

    public void CollisionWithPlayerExit()
    {
        controlEnemigo.SetBool("attack", false);
        if (!isDead)
        {
            perseguir = true;
        }

    }

    public void CollisionWithBullet()
    {
        Debug.Log("MUERO! >.<");
        perseguir = false;
        isDead = true;
        controlEnemigo.SetBool("morir", true);
        controlEnemigo.SetBool("attack", false);
        
        Invoke("DestroyEnemy", 5.5f);
        SendMessageUpwards("EnemyKilled");

    }

    public void WeaponHit()
    {
        Debug.Log("BONK!!!!!");
        script.GameOverUI();
        controlEnemigo.SetBool("attack", false);

    }

    public void DestroyEnemy()
    {
     
        Destroy(this.gameObject);
    }




}