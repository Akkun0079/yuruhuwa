using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
           GameManager gameManager = FindObjectOfType<GameManager>();
        if(!gameManager == false)
        {           
           gameManager.ticketGet = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
