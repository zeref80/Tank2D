using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankMovement : MonoBehaviour
{
    public int movementSpeed = 0;
    public int rotationSpeedTank = 0;
    public int rotationSpeedTurret = 0;

    Transform tankBody;
    Transform tankTurret;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tankBody = transform.Find("Chassie");
        tankTurret = transform.Find("Turret");

    }

    public void MovePlayer(float inputValue)
    {
        rb2d.velocity = tankBody.right * inputValue * movementSpeed;
    }


    public void RotateTankTurret(Vector3 endpoint)
    {
        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, endpoint - tankTurret.position);
        desiredRotation = Quaternion.Euler(0, 0, desiredRotation.eulerAngles.z + 900);
        tankTurret.rotation = Quaternion.RotateTowards(tankTurret.rotation, desiredRotation, rotationSpeedTurret * Time.deltaTime);

    }


    public void RotateTankBody(float inputDirection)
    {
        float rotation = -inputDirection * rotationSpeedTank;
        tankBody.Rotate(Vector3.forward * rotation);

    }
}
