using UnityEngine;
using UnityEngine.AI;

public enum State
{
    STATIONARY,
    PATROLLING,
    FLEEING
};

public class MerchantShipMovement : MonoBehaviour
{
    State state;

    public Transform target;
    NavMeshAgent agent;
    Vector3 targetPos;
    public GameObject player;
    float timer;

    int fleeEngageOffset = 250;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        GetRandomLocation();

        state = State.PATROLLING;
    }

    /// <summary>
    ///     Makes the merchant ship exhibit patrolling, fleeing and stationary behaviours. If the player gets too close to the merchant ship
    ///     they begin to flee.
    /// </summary>
    void Update()
    {
        if((this.transform.position.x >= player.transform.position.x - fleeEngageOffset && this.transform.position.x <= player.transform.position.x + fleeEngageOffset)
            && (this.transform.position.z >= player.transform.position.z - fleeEngageOffset && this.transform.position.z <= player.transform.position.z + fleeEngageOffset)) {
            state = State.FLEEING;
        }

        switch (state) {
            case State.STATIONARY:
                timer += Time.deltaTime;
                if(timer >= 0) {
                    state = State.PATROLLING;
                    timer = 0;
                }
                break;

            case State.PATROLLING:
                if (agent.isStopped) {
                    GetRandomLocation();
                }
                agent.SetDestination(targetPos);
                break;

            case State.FLEEING:
                targetPos = new Vector3(-player.transform.position.x, 0, -player.transform.position.z);
                agent.SetDestination(targetPos);
                if (agent.isStopped) {
                    state = State.STATIONARY;
                }
                break;

            default:
                Debug.Log("Default case was hit!");
                break;
        }
    }

    //  Gets a random location on the map.
    void GetRandomLocation()
    {
        var x = Random.Range(-1200, 1200);
        var z = Random.Range(-1200, 1200);
        targetPos = new Vector3(x, 0, z);
    }
}
