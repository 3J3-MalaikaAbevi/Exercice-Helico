using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTremblementFPS : MonoBehaviour
{
    public GameObject refHelice;
    Vector3 limiteTremblement;
    public Vector3 maxTremblement;

    // Update is called once per frame
    void Update()
    {
        if (refHelice.GetComponent<TournerHelice>().moteurEnMarche)
        {
            transform.Translate(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0f);
        }

        limiteTremblement.z = 0;

        if (Mathf.Abs(transform.localPosition.x) > maxTremblement.x)
        {
            if (transform.localPosition.x > 0f)
            {
                limiteTremblement.x = maxTremblement.x;
                //print("positif");
            }   
            if (transform.localPosition.x < 0)
            {
                limiteTremblement.x = -(maxTremblement.x);
                //print("negatif");
            }

            transform.localPosition = limiteTremblement;
        }

        if (Mathf.Abs(transform.localPosition.y) > maxTremblement.y)
        { 
            if (transform.localPosition.y > 0)
            {
                limiteTremblement.y = maxTremblement.y;
            }
            else if (transform.localPosition.y < 0)
            {
                limiteTremblement.y = -maxTremblement.y;
            }

            transform.localPosition = limiteTremblement;
        }

        
    }
}
