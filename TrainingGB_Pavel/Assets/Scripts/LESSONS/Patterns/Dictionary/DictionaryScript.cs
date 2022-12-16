using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryScript : MonoBehaviour, ISerializationCallbackReceiver {
    [SerializeField] private List<string> keys = new List<string>();
    [SerializeField] private List<int> values = new List<int>();
    [SerializeField] private DictionaryScriptableObject dictionaryData;
    private Dictionary<string, int> _myDictionary = new Dictionary<string, int>();
    public bool modifyValues;

    private void Awake() {
        for (int i = 0; i < Mathf.Min(dictionaryData.Keys.Count, dictionaryData.Values.Count); i++) {
          
            _myDictionary.Add(dictionaryData.Keys[i], dictionaryData.Values[i]);
        }
    }
    public void OnAfterDeserialize() {
        if (!modifyValues) {
            keys.Clear();
            values.Clear();
            for (int i = 0; i < Mathf.Min(dictionaryData.Keys.Count, dictionaryData.Values.Count); i++) {//берем минимальное значение из нашего словаря
                keys.Add(dictionaryData.Keys[i]);
                values.Add(dictionaryData.Values[i]);
            }
        }
    }
    public void OnBeforeSerialize() {

    }
    public void DeserializeDictionary() {
        Debug.Log("DeserializeDictionary");
        _myDictionary = new Dictionary<string, int>();
        dictionaryData.Keys.Clear();
        dictionaryData.Values.Clear();
        for (int i = 0; i < Mathf.Min(keys.Count, values.Count); i++) {
            dictionaryData.Keys.Add(keys[i]);
            dictionaryData.Values.Add(values[i]);
            _myDictionary.Add(keys[i], values[i]);
        }
        modifyValues = false;
    }
    public void PrintDictionary() {

        foreach (var pair in _myDictionary) {
            Debug.Log("Key: " + pair.Key + " Value: " + pair.Value);
        }

    }
}
