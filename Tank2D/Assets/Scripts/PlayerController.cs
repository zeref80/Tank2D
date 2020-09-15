using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _horizontalInput = 0;
    private float _verticalInput = 0;
    private Vector3 _mousePosition;
    PlayerTankMovement movementScript;

    void Start()
    {
        movementScript = GetComponent<PlayerTankMovement>();
    }

    void FixedUpdate()
    {
        movementScript.MovePlayer(Mathf.Abs(_verticalInput));
        if (_horizontalInput != 0)
            movementScript.RotateTankBody(_horizontalInput);  

        //Vertical w jedną stronę, do przyjrzenia się potem

    }

    void Update()
    {
        GetPlayerInput();
        movementScript.RotateTankTurret(_mousePosition);
    }

    private void GetPlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");   
        Vector3 mousePosition3d = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        _mousePosition = new Vector3(mousePosition3d.x, mousePosition3d.y, 0);

    }
}
