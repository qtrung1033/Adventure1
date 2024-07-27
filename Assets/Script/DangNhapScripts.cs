using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class DangNhapScripts : MonoBehaviour
{
    public TMP_InputField edtUser, edtPass, edtRePass;
    public TMP_Text txtMessage;
   

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DangNhap()
    {
        StartCoroutine(Login());
        Login();
    }
    IEnumerator Login()
    {
        // lấy giá trị từ InputField

        string user = edtUser.text;
        string pass = edtPass.text;
        txtMessage.text = "";

        if (pass.Equals(pass))
        {
            UserDangNhapModel userDangNhapModel = new UserDangNhapModel(user, pass);
            string jsonStringRequest = JsonConvert.SerializeObject(userDangNhapModel);

            var request = new UnityWebRequest("http://localhost:3002/apis/login", "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                var jsonString = request.downloadHandler.text.ToString();
                MessageModel message = JsonConvert.DeserializeObject<MessageModel>(jsonString);
                txtMessage.text = message.notification;
                if(message.status == 1)
                {
                    SceneManager.LoadScene("Màn 1");
                }
            }
            request.Dispose();
        }

        else
        {
            //hiện thị thông báo
            txtMessage.text = "Mật khẩu không đúng";
        }

    }
}
