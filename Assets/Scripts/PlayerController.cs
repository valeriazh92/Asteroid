using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController :  IBoundariesFinder
{
    private SpaceshipView spaceshipView;
    private PlayerAction playerAction;
    private float speed = 3.0f;
    private Vector2 minBoundaries, maxBoundaries;
    private Camera mainCam;
    
    Vector2 Forward => Quaternion.Euler(0, 0, spaceshipView.transform.rotation.z) * Vector3.right;
    Vector2 Acceleration;

    public PlayerController(SpaceshipView view)
    {
        spaceshipView = view;
        Awake();
    }

    private void Awake()
    {
        playerAction = new PlayerAction();
        playerAction.Player.Move.performed += Accelerate;
        
        mainCam = Camera.main;
        CheckBoundaries();
    }
    public void OnEnable()
    {
        playerAction.Enable();
    }
    public void OnDisable()
    {
        playerAction.Disable();
    }
    private void Move()
    {
        Debug.Log("Move");
        spaceshipView.transform.Translate(Acceleration.x, Acceleration.y, 0f);
        Decelerate();
    }
    
    public void Update()
    {

        Move();
        CrossBoubdaries();
        spaceshipView.transform.Rotate(0, 0, speed * playerAction.Player.Look.ReadValue<Vector2>().x);
       
    }
    void Accelerate(InputAction.CallbackContext context)
    {
        Acceleration += Forward * (0.1f * Time.deltaTime);
        Acceleration = Vector2.ClampMagnitude(Acceleration, 0.30f);
    }

    void Decelerate()
    {
        Acceleration -= Acceleration* Time.deltaTime / 2.0f;
        
    }
   
    public void CheckBoundaries()
    {
        minBoundaries = mainCam.ViewportToWorldPoint(new Vector2(0f, 0f));
        maxBoundaries = mainCam.ViewportToWorldPoint(new Vector2(1f, 1f));
    }

    public void CrossBoubdaries()
    {
        if (spaceshipView.transform.position.x > maxBoundaries.x) { spaceshipView.transform.position = new Vector3(minBoundaries.x, spaceshipView.transform.position.y, 0f); }
        if (spaceshipView.transform.position.x < minBoundaries.x) { spaceshipView.transform.position = new Vector3(maxBoundaries.x, spaceshipView.transform.position.y, 0f); }
        if (spaceshipView.transform.position.y > maxBoundaries.y) { spaceshipView.transform.position = new Vector3(spaceshipView.transform.position.x, minBoundaries.y, 0f); }
        if (spaceshipView.transform.position.y < minBoundaries.y) { spaceshipView.transform.position = new Vector3(spaceshipView.transform.position.x, maxBoundaries.y, 0f); }
    }
}
 