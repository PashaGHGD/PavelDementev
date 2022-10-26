using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveTxt : MonoBehaviour {

    
    private SaveData _saveData = new SaveData() { Position = new Vector3(10f, 15f, 20f) };
    private StreamData _streamData = new StreamData();




    void Start() {
        var path = Path.Combine(Application.streamingAssetsPath, "SaveData.txt");
        // Save(path, "Save data");
        var save = _streamData.Load(path);
        //  _streamData.Save(_saveData, path);

        transform.position =save.Position;

    }


    private void Save(string path, string data) {
        using (var sw = new StreamWriter(path)) {
            sw.WriteLine(data);
        }
    }

    public string Load(string path = null) {

        var result = "";

        using (var sr = new StreamReader(path)) {

            while (!sr.EndOfStream) {

                result += sr.ReadLine();

            }


        }
        return result;
    }

}
