using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Route currentRoute;
    public int routePosition;
    public Node currentNode;
    public int steps;
    bool isMoving;

    public bool isCurrentTurn = false;

    public void ActiveTurn()
    {
        isCurrentTurn = true;
    }

    public void DeActiveTurn()
    {
        isCurrentTurn = false;
    }


    private void Awake() 
    {
        currentRoute = GameObject.Find("Route").GetComponent<Route>();
    }
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isMoving && isCurrentTurn)
        {
            steps = Random.Range(1,7);
            Debug.Log("Dice rolled " + steps);

            StartCoroutine(Move());
        }
    }

    void EventTrigger()
    {
        //trigger event on routePosition's Node
        currentNode = currentRoute.childNodeList[routePosition].GetComponent<Node>();
        currentNode.StartEvent(this.gameObject);
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

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position,goal,8f * Time.deltaTime));
    }


}
