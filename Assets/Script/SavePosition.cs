    /*using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.SceneManagement;
    using static UnityEditor.ShaderData;

    public class SavePosition : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
        
        }
        public void SavePositionPlayer()
        {

        }
        *//*IEnumerator Login()
        {
        
            //string jsonStringRequest = JsonConvert.SerializeObject(UserDangNhapModel);

            var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/login", "POST");
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
            
            }
            request.Dispose();*//*

        

        }
    }
    */