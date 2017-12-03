using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 3f, -5f);


    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
