using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class StreamData : IData<SaveData>
{
   public void Save(SaveData data, string path = null) {

        if (path == null) return;

        using (var sw  = new StreamWriter(path)) {

            sw.WriteLine(data.Position.X);
            sw.WriteLine(data.Position.Y);
            sw.WriteLine(data.Position.Z);

        }

       
    }
    public SaveData Load(string path = null) {

        var result = new SaveData();

        using (var sr = new StreamReader(path)) {

            while (!sr.EndOfStream) {

                result.Position.X = sr.ReadLine().Length;
                result.Position.Y = sr.ReadLine().Length;
                result.Position.Z = sr.ReadLine().Length;
            }

            return result;
        }


    }
}
