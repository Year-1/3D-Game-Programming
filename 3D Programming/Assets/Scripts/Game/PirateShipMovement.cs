using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public enum Action
{
    STATIONARY,
    PATROLLING,
    ATTACKING
};

public class PirateShipMovement : MonoBehaviour
{
    //  Make it so you can only shoot during attack mode?
    Action action;
    NavMeshAgent agent;
    Vector3 targetPos;
    ShipRotation shiprot;
    bool patrolling = false;
    bool shooting = false;

    public GameObject thisPirateShip;
    PirateShoot pirateShoot;
    public GameObject playerPos;
    public Transform target;

    public float timer = 0;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player");
        pirateShoot = thisPirateShip.GetComponent<PirateShoot>();
        shiprot = thisPirateShip.GetComponent<ShipRotation>();
        agent = GetComponent<NavMeshAgent>();
        GetRandomLocation();
        action = Action.PATROLLING;
    }

    /// <summary>
    ///     Updates the pirates behaviour and what behaviour to exhibit. Switches between 
    ///     Attacking, Patrolling and Stationary.
    /// </summary>
    void Update()
    {
        thisPirateShip.transform.position = this.transform.position;

        timer += Time.deltaTime;
        switch (action) {
            case Action.STATIONARY:
                shooting = false;
                agent.isStopped = true;
                if (timer >= 15f) {
                    action = Action.PATROLLING;
                    timer = 0;
                }
                shiprot.PatrollingRotation();
                pirateShoot.StopShooting();
                patrolling = false;
                break;

            case Action.PATROLLING:
                agent.isStopped = false;
                shooting = false;
                if (timer >= 10) {
                    action = Action.ATTACKING;
                    timer = 0;
                }
                if (!patrolling) {
                    patrolling = true;
                }
                if (agent.isStopped) {
                    GetRandomLocation();
                }
                shiprot.PatrollingRotation();
                agent.SetDestination(targetPos);
                pirateShoot.StopShooting();
                break;

            case Action.ATTACKING:
                if (timer >= 10f) {
                    action = Action.STATIONARY;
                    timer = 0;
                }
                agent.isStopped = true;
                patrolling = false;
                if (!shooting) {
                    pirateShoot.Shoot();
                    shooting = true;
                }                
                shiprot.AttackingRotation();
                transform.LookAt(playerPos.transform);
                break;

            default:
                patrolling = false;
                Debug.Log("Default case was hit");
                break;
        }
    }

    //  Gets a random location on the map.
    void GetRandomLocation()
    {
        var x = Random.Range(-1200, 1200);
        var y = Random.Range(-1200, 1200);
        targetPos = new Vector3(x, 0, y);
    }
}
