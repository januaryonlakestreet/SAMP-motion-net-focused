using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Draw_Joints : MonoBehaviour
{
    public float Size = 0.91f;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, Size);

        if(Target != null)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawLine(this.transform.position, Target.position);
        }
    
    }
}
