using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTracker : MonoBehaviour
{
    [SerializeField] private Circle _circle;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        transform.position = new Vector3(_circle.transform.position.x + _xOffset, transform.position.y, transform.position.z);
    }
}
