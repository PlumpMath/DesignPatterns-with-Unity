using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform PlayerTransform;

    private const float JumpVelocity = 3f;

    
    private float vx;
    private float vy;
    private Vector3 velocity;

    private void Awake()
    {
        
    }

    private void Start () {
		
	}

    private void Update () {
		//PlayerTransform.

	}

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vy = JumpVelocity;
            SetGraphics();
        }
        
    }

    private void SetGraphics()
    {
        
    }
}
