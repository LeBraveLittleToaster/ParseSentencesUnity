using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class LoadSentencesScript : MonoBehaviour
{
    public TextAsset jsonDataTxt;

    // Start is called before the first frame update
    void Start()
    {
        // Dictionary with id field as key and Dialog object as value
        var dictionaryWithIdToDialo = getDialogues(jsonDataTxt.text);

        //dialog is assigned if the next method succeeds
        Dialog dialog;
        if (dictionaryWithIdToDialo.TryGetValue("id1", out dialog))
        {
            //it return a value, this value in now in dialog
            Debug.Log("id1 answers => " + dialog.Sentence);
        }
        else
        {
            //there was no key with "id1" so the TryGetValue returned false
            Debug.Log("id1 not present in Dictionary");
            // change id in line 18 to an id that is not present trigger the else
        }
    }


    private Dictionary<string, Dialog> getDialogues(string json)
    {
        var sentenceData = JsonUtility.FromJson<SentenceCollection>(json);
        
        Debug.Log("Loaded " + sentenceData.sentences.Count + " amount of sentences");
        return sentenceData.sentences.ToDictionary(sentence => sentence.id,
            sentence => new Dialog(sentence.sentence, sentence.answers, sentence.propertyId));
    }
}