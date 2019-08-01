using UnityEngine;
using System.Collections;

// source - https://www.gamasutra.com/blogs/VivekTank/20180709/321571/Different_Ways_Of_Shaking_Camera_In_Unity.php


public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude, float speed)
    {
        Debug.Log("shake now!");
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
            elapsed += Time.deltaTime * speed;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}