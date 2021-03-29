using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    public Vector3 minScale;
    public Vector3 maxScale;
    public bool repeat;
    public float speed = 2f;
    public float duration = 5;
    

    // Start is called before the first frame update
    
    public IEnumerator call_big()
    {
       
        yield return fun(minScale, maxScale, duration);
        
    }
    public IEnumerator call_small()
    {
        yield return fun(maxScale, minScale, duration);
    }
    public IEnumerator fun(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
