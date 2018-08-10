using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    public GameObject player;
    public Vector2 prevMouse, currentMouse;

    public float angle, distance;

    void Start ()
    {
        player = this.gameObject;
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
            TouchIn();
        else if (Input.GetMouseButtonUp(0))
            TouchOut();
	}

    public void TouchIn()
    {
        prevMouse = Input.mousePosition;
    }

    public void TouchOut()
    {
        currentMouse = Input.mousePosition;

        rigidbody2D.AddForce(prevMouse - currentMouse);

        distance = Vector2.Distance(prevMouse, currentMouse);
        angle = Vector2.Angle(prevMouse, currentMouse);

        //player.transform.eulerAngles = new Vector3(0, 0, angle);

        //player.transform.Translate(Vector2.up * 1);
        
        Debug.Log("Distance: " + distance.ToString());
        Debug.Log("Angle: " + angle.ToString());
    }
}
