using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Vector2 prevMouse, currentMouse;

    public float angle, distance;

    private void Start()
    {
        if (!isLocalPlayer)
            return;

        GameObject.Find("JoinGame").SetActive(false);
    }

    void Update ()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetMouseButtonDown(0))
            TouchIn();
        else if (Input.GetMouseButtonUp(0))
            TouchOut();

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector2.down * .05f);
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
