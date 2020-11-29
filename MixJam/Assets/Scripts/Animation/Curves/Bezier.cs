using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics.Animation
{
	public class Bezier
	{
		public Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
		{
			float u = 1 - t;
			float tt = t * t;
			float uu = u * u;

			Vector3 p = uu * p0; //first term
			p += 2 * u * t * p1; //second term
			p += tt * p2; //third term

			return p;
		}

		public Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			float u = 1 - t;
			float tt = t * t;
			float uu = u * u;
			float uuu = uu * u;
			float ttt = tt * t;

			Vector3 p = uuu * p0; //first term
			p += 3 * uu * t * p1; //second term
			p += 3 * u * tt * p2; //third term
			p += ttt * p3; //fourth term

			return p;
		}
	}
}
