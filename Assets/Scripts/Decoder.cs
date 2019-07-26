using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

/*
    Decoder class can manipulate with user input.
 */
public class Decoder : MonoBehaviour
{
    public InputField inPutText;    
    public InputField outPutText;
    public static Dictionary<string, Vector3> coords; //Dictionary contains bonds between Vector3 coordinates and type of "a2" coordinates. Filling up in MovementManager Awake() method.
    string[] comands;

    public void Decode()
    {
        comands = inPutText.text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);  //Split by ' ' symbol. Get coordinates type of "a2".
        MovementManager.Move(coords[comands[0]],coords[comands[1]], (MovementManager.turnCouter % 2 == 1)); //Pass Vector3 coordinate to Move() and bool. If turn counter is odd - it's white's turn.
        outPutText.text += '\n' + ResultOfTurn(MovementManager.WrongTurn);  //Check for illegal moves.
        inPutText.text = "";    //Clear input.
    }

    public string ResultOfTurn(bool WrongTurn)
    {
        if(WrongTurn)
        {
            //There is no incrementing turnCounter with illegal move.
            return "Wrong Turn!";
        }
        else
        {
            MovementManager.turnCouter++;   //Passing turn.
            return ((MovementManager.turnCouter-1).ToString() + ". " + inPutText.text); //Record turn.
        }
    }
}
