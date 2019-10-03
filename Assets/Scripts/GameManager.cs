using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    bool playerTurn;
    List<Actors> actors;

    void Start()
    {
       actors = FindObjectsOfType<Actors>().ToList<Actors>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
