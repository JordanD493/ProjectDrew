using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField]
    private Transform[] controllPoints;

    private Vector3 gizmoPosition;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnDrawGizmos()
    {
        for(float i = 0; i<=1; i += 0.05f )
        {
            gizmoPosition = Mathf.Pow(1 - i, 3) * controllPoints[0].position +
                            3 * Mathf.Pow(1 - i, 2) * i * controllPoints[1].position +
                            3 * (1 - i) * Mathf.Pow(i, 2) * controllPoints[2].position +
                            Mathf.Pow(i, 3) * controllPoints[3].position;

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(gizmoPosition, 0.25f);
        }

        Gizmos.DrawLine(new Vector3(controllPoints[0].position.x, controllPoints[0].position.y, controllPoints[0].position.z),
                        new Vector3(controllPoints[1].position.x, controllPoints[1].position.y, controllPoints[1].position.z));

        Gizmos.DrawLine(new Vector3(controllPoints[2].position.x, controllPoints[2].position.y, controllPoints[2].position.z),
                        new Vector3(controllPoints[3].position.x, controllPoints[3].position.y, controllPoints[3].position.z));

    }
}
