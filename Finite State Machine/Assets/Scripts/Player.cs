using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    string currentState;
    IPlayerState _currentState;
    public float jumpSpeed = 3f;

    void Awake()
    {
        StandUp();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case "standing":
                if (Input.GetKeyDown(KeyCode.Space))
                    Jump();
                if (Input.GetKeyDown(KeyCode.LeftControl))
                    Duck();
                break;
            case "jumping":
                if (Input.GetKeyDown(KeyCode.LeftControl))
                    Dive();
                break;
            // Diving's state transition is handled on collision with ground (below)
            case "ducking":
                if (Input.GetKeyDown(KeyCode.Space))
                    StandUp();
                break;
            default:
                break;
        }
    }
    public void StandUp()
    {
        currentState = "standing";
        _currentState = new Standing();
        _currentState.Execute(this);
    }
    public void Jump()
    {
        currentState = "jumping";
        _currentState = new Jumping();
        _currentState.Execute(this);
    }
    public void Dive()
    {
        currentState = "diving";
        _currentState = new Diving();
        _currentState.Execute(this);
    }
    public void Duck()
    {
        currentState = "ducking";
        _currentState = new Ducking();
        _currentState.Execute(this);
    }

    // Detect Collision with ground to move into standing state
    private void OnCollisionEnter(Collision collision)
    {
        if (currentState == "jumping" || currentState == "diving" && collision.collider.tag == "Ground")
        {
            Debug.Log("Impact");
            StandUp();
        }
    }
}

