using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    NavMeshAgent nav;
    Transform playerTransform;

    public float patrolSpeed = 1.5f;
    public float chaseSpeed = 2;

    public float chaseRadius = 8;
    public float interactRadius = 1.5f;

    Vector3 randomStart;
    public float pointTriggerDistance = 1;
    public float patrolRandomDistance = 1;

    Transform chaseTarget;
    //bool isChasing = false;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        randomStart = transform.position;

        StartSearch();
    }

    public void StartSearch()
    {
        chaseTarget = null;

        nav.speed = patrolSpeed;

        StartCoroutine(SearchRoutine());
        StartCoroutine(PatrolRandomRoutine());
    }

    public void StartChase(Transform target)
    {
        chaseTarget = target;

        nav.speed = chaseSpeed;

        StartCoroutine(ChaseRoutine());
    }

    IEnumerator PatrolRandomRoutine()
    {
        nav.SetDestination(randomStart);
        while (chaseTarget == null)
        {
            if (Vector3.Distance(transform.position, nav.destination) <= pointTriggerDistance)
            {
                float rndm = Random.Range(0.5f, 2);
                yield return new WaitForSeconds(rndm);

                Vector3 randomDirection = Random.insideUnitSphere * patrolRandomDistance;
                randomDirection += randomStart;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, patrolRandomDistance, 1);
                Vector3 finalPosition = hit.position;

                nav.SetDestination(finalPosition);
            }

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator SearchRoutine()
    {
        Debug.Log("started searching");
        while (chaseTarget == null)
        {
            Vector3 loweredPlayerPos = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);

            if (Vector3.Distance(transform.position, loweredPlayerPos) <= chaseRadius)
            {
                StartChase(playerTransform);
                //isChasing = true;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator ChaseRoutine()
    {
        Debug.Log("started chasing");
        while (chaseTarget != null)
        {
            nav.SetDestination(chaseTarget.position);

            if (Vector3.Distance(transform.position, chaseTarget.position) <= chaseRadius)
            {
                if (chaseTarget == playerTransform)
                {
                    //attack player
                }
                else
                {
                    StartSearch();
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
