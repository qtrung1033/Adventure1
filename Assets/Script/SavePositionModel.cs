using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePositionModel 
{
    public SavePositionModel(string username, string positionX, string positionY, string positionZs)
    {
        this.username = username;
        this.positionX = positionX;
        this.positionY = positionY;
        this.positionZ = positionZ;
    }

    public string username {  get; set; }
    public string positionX { get; set; }
    public string positionY { get; set; }
    public string positionZ { get; set; }
}
