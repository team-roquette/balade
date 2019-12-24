using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boyfriend : MonoBehaviour
{

    public Transform goal;

    NavMeshAgent agent;
    bool updatePath = true;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(CalcPath());

    }

    IEnumerator CalcPath()
    {
        while (true)
        {

            updatePath = Vector3.Distance(transform.position, goal.position) < 6.0f ? false : true;

            if (updatePath)
            {
                yield return new WaitForSeconds(0.2f);
                agent.SetDestination(goal.position);
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Vector3.Distance(transform.position, goal.position) > 10.0f)
        {
            agent.speed = 7.0f;
        }
        else if(Vector3.Distance(transform.position, goal.position) < 7.0f)
        {
            agent.speed = 3.5f;
        }


        if (IsAtDestination())
        {
            transform.LookAt(goal.position);
        }

        //agent.destination = goal.position;
    }

    private bool IsAtDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
