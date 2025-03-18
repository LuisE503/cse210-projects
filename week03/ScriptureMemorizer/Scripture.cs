using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.ConvertAll(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{scriptureText}";
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide)
        {
            List<Word> visibleWords = _words.FindAll(word => !word.IsHidden());

            if (visibleWords.Count == 0)
            {
                break;
            }

            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            hiddenCount++;
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.TrueForAll(word => word.IsHidden());
    }
}
