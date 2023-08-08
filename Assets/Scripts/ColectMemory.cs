using UnityEngine;
using System.Collections;
using System;

public class ColectMemory : MonoBehaviour {
    string txt = "fadsfasdfasdf";

	// Use this for initialization
	void Start () {
        print(txt);
        print("memory before colection:" + GC.GetTotalMemory(false));
        txt = null;
        GC.Collect();
        print(txt+"_memory colected:" + GC.GetTotalMemory(true));


    }

  
	
	// Update is called once per frame
	void Update () {
	
	}
}
