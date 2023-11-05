using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingParallax : MonoBehaviour
{

    [Range(1f, 20f)]
    public float ScrollSpeed = 1;
    public float ScrollOffset;

    Vector2 StartPos;

    float NawPos;
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        NawPos = Mathf.Repeat(Time.time * -ScrollSpeed,ScrollOffset);
        transform.position = StartPos + Vector2.right * NawPos;
    }
}
