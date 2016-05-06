using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour {
	public void StartGame(){
		SceneManager.LoadScene (1);
	}
	public void QuitGame(){
		Application.Quit ();
	}
}
