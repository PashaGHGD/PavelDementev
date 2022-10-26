using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lesson_7 : MonoBehaviour {
    List<int> ListT = new List<int>();
    [SerializeField] int a = 1;// от какова числа
    [SerializeField] int b = 10;// до какова числа
    [SerializeField] int c = 10;// количество чисел
   
    private void Start() {


        RandomList(a, b, c);
    }

    public void RandomList(int a, int b, int c) {
        int s;
        // int res = 0;


        for (int i = 0; i < c; i++) {
            s = Random.Range(a, b);
            ListT.Add(s);
        }
        foreach (int val in ListT.Distinct()) {
            Debug.Log(val + " - " + ListT.Where(x => x == val).Count() + " раз");
        }
      Debug.Log("количество символов в строке = " + MyExtension.Len("12345")); 
    }




}
public static class MyExtension {


    public static int Len(this string self) {

        int res = 0;

        for (int i = 0; i < self.Length; i++) {
            res++;
        }

        return res;

    }


}
