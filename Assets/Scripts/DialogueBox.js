#pragma strict

var toggleGUI : boolean;

var guiStyle : GUIStyle;

    function OnTriggerEnter2D (other : Collider2D) {
    if(other.gameObject.tag == "exit") {
	    Debug.Log("on");
	    toggleGUI = true;
	   }
    }
     
    function OnTriggerExit2D (other : Collider2D) {
    /*if(other.gameObject.tag == "exit") {
	    Debug.Log("off");
	    toggleGUI = false;
	   }*/
    }
    
    function OnGUI () {
	    if (toggleGUI == true) {
		    Debug.Log("dialogue");
		    GUI.Box (Rect (0, 0, Screen.width, Screen.height), "such shinobi, very inu, wow", guiStyle);
		    Debug.Log("box");
	    }
	}


function Start () {

}

function Update () {


}