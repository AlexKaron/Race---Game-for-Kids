using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCylinder : MonoBehaviour
{
    public Transform startPosition;
   public Transform endPosition;
   public bool repeatable = false;
   public float speed = 2f;
   float startTime,totalDistance;
   public float duration=3f;

   IEnumerator Start()
   {
    startTime=Time.time;
    totalDistance= Vector3.Distance(startPosition.position,endPosition.position);
    while (repeatable)
    {
        yield return RepeatLerp (startPosition.position,endPosition.position,duration);
        yield return RepeatLerp (endPosition.position,startPosition.position,duration);
    }
   }

    void Update()
    {
  
        if(!repeatable)
        {
            float currentDuration = (Time.time -startTime) * speed;
            float journeyFraction = currentDuration / totalDistance;
            this.transform.position= Vector3.Lerp(startPosition.position,endPosition.position,journeyFraction);
        }
    }

    public IEnumerator RepeatLerp (Vector3 a, Vector3 b,  float time)
    {
        float i = 0f;
        float rate = (1f/time)* speed;
        while (i< 1f)
        {
            i += Time.deltaTime * rate;
            this.transform.position = Vector3.Lerp(a,b,i);
            yield return null;
        }
    }
}
