using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "one")
        {
            GameObject.Find("GameManager").GetComponent<Scroll>().productName = 1;
        }
        else if (other.gameObject.tag == "two")
        {
            GameObject.Find("GameManager").GetComponent<Scroll>().productName = 2;
        }
        else if (other.gameObject.tag == "thr")
        {
            GameObject.Find("GameManager").GetComponent<Scroll>().productName = 3;
        }
        else if (other.gameObject.tag == "fou")
        {
            GameObject.Find("GameManager").GetComponent<Scroll>().productName = 4;
        }
        else if (other.gameObject.tag == "fiv")
        {
            GameObject.Find("GameManager").GetComponent<Scroll>().productName = 5;
        }
        else if (other.gameObject.tag == "six")
        {
            GameObject.Find("GameManager").GetComponent<Scroll>().productName = 6;
        }
    }
}