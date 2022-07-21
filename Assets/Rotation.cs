using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector3 RotationVelocity;

    void Update()
    {
        Quaternion rotation = Quaternion.Euler(RotationVelocity * Time.deltaTime);
        transform.rotation = rotation * transform.rotation;
    }
}
