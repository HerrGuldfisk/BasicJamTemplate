using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundPairPointInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		GameManager.Instance.pairPoint = transform.position;
    }


}
