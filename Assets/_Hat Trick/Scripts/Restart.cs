using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	// Use this for initialization
	public void restartGame ()
    {
        Debug.Log("Poop");
        SceneManager.LoadScene("main");        
    }
}
