using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyUtil
{
    public static float GetAngle(Vector3 start,Vector3 end)
    {
        return Mathf.Atan2(start.z - end.z,start.x - end.x) * 180f / Mathf.PI ;
    }
	
}
