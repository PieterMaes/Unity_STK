using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFunction : MonoBehaviour
{
    [Header("New Speed Variables")]
    public float newX_Speed;
    public float newY_Speed;
    void OnMouseDown()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            newX_Speed, newY_Speed
            );
    }
}
