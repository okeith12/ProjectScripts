using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    public string name;
    [TextArea(3,15)] //ALLOWS FOR THE TEST FIELD TO BE BIGGER FOR MORE DIALOGUE
    public string[] sentences;

}
