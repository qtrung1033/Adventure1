using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDangNhapModel
{
    public UserDangNhapModel(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public string username { get; set; }
    public string password { get; set; }
}
