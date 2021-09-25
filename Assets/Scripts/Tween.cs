using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform Target { get; }
    public Vector3 StartPos { get; }
    public Vector3 EndPos { get; }
    public float StartTime { get; }
    public float Duration { get; }

   

    public Tween(Transform Target, Vector3 StartPos, Vector3 EndPos, float StartTime, float Duration)
    {
        this.Target = Target;
        this.StartPos = StartPos;
        this.EndPos = EndPos;
        this.StartTime = StartTime;
        this.Duration = Duration;
    }
    
  

}
