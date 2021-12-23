using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IBoundariesFinder
{
    private PlayerAction playerAction;
    private float speed = 3.0f;
    private Vector2 minBoundaries, maxBoundaries;
    private     Camera mainCam;
    



    Vector2 Forward => Quaternion.Euler(0, 0, transform.rotation.z) * Vector3.right;
    Vector2 Acceleration;
    private void Awake()
    {
        playerAction = new PlayerAction();
        playerAction.Player.Move.performed += Accelerate;
        mainCam = Camera.main;
        CheckBoundaries();

    }
    private void OnEnable()
    {
        playerAction.Enable();
    }
    private void OnDisable()
    {
        playerAction.Disable();
    }
    private void Move()
    {
        Debug.Log("Move");
        transform.Translate(Acceleration.x, Acceleration.y, 0f);
        Decelerate();
    }
    void Start()
    {
      
    }

    void Update()
    {

        Move();
        CrossBoubdaries();
        transform.Rotate(0, 0, speed * playerAction.Player.Look.ReadValue<Vector2>().x);

    }
    void Accelerate(InputAction.CallbackContext context)
    {
        Acceleration += Forward * (0.1f * Time.deltaTime);
        Acceleration = Vector2.ClampMagnitude(Acceleration, 0.15f);
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
        if (transform.position.x > maxBoundaries.x) { transform.position = new Vector3(minBoundaries.x, transform.position.y, 0f); }
        if (transform.position.x < minBoundaries.x) { transform.position = new Vector3(maxBoundaries.x, transform.position.y, 0f); }
        if (transform.position.y > maxBoundaries.y) { transform.position = new Vector3(transform.position.x, minBoundaries.y, 0f); }
        if (transform.position.y < minBoundaries.y) { transform.position = new Vector3(transform.position.x, maxBoundaries.y, 0f); }
    }
}
 