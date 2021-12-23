using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private PlayerController playerController;
    

    [SerializeField] private SpaceshipView spaceshipView;
    void Awake()
    {
        playerController = new PlayerController(spaceshipView);
        playerController.OnEnable();

    }

    void Update()
    {
        playerController.Update();
        
    }
}
