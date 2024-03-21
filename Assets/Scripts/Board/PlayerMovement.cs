using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Route currentRoute;
    public int routePosition;
    public Node currentNode;
    public int steps;
    bool isMoving;

    public bool isCurrentTurn;
    public bool isFighting;

    private void Awake() 
    {
        currentRoute = GameObject.Find("Route").GetComponent<Route>();
    }
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isMoving && isCurrentTurn && !isFighting)
        {
            steps = Random.Range(1,7);
            Debug.Log("Dice rolled " + steps);

            StartCoroutine(Move());
        }
    }



    IEnumerator Move()
    {
        if(isMoving)
        {
            yield break;
        }
        isMoving = true;

        while(steps >0)
        {
            routePosition++;
            routePosition %= currentRoute.childNodeList.Count;

            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
            while(MoveToNextNode(nextPos)){yield return null;}

            yield return new WaitForSeconds(0.1f);
            steps--;
        }

        isMoving = false;
        EventTrigger();
    }

    void EventTrigger()
    {
        //trigger event on routePosition's Node
        currentNode = currentRoute.childNodeList[routePosition].GetComponent<Node>();
        currentNode.StartEvent(this.gameObject);
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position,goal,8f * Time.deltaTime));
    }

    public void ActiveTurn()
    {
        isCurrentTurn = true;
        Debug.Log("Active Turn");
        StartCoroutine(CheckInBattle());
    }

    public void DeActiveTurn()
    {
        isCurrentTurn = false;
    }

    IEnumerator CheckInBattle()
    {
        yield return new WaitForSeconds(2f);
        if(isFighting)
        {
            
            Debug.Log("Repeat Battle");
            EventTrigger();
        }
    }


}
