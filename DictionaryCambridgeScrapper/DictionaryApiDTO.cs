﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InglesToAnki
{
    public class DictionaryApiDTO
    {
        public string? word { get; set; }
        public string? phonetic { get; set; }
        public List<Phonetic>? phonetics { get; set; }
        public List<Meaning>? meanings { get; set; }
        public License? license { get; set; }
        public List<string>? sourceUrls { get; set; }
    }

    public class License
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Phonetic
    {
        public string? text { get; set; }
        public string? audio { get; set; }
        public string? sourceUrl { get; set; }
        public License1? license { get; set; }
    }

    public class License1
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Meaning
    {
        public string? partOfSpeech { get; set; }
        public List<Definition>? definitions { get; set; }
        public List<string>? synonyms { get; set; }
        public List<string>? antonyms { get; set; }
    }

    public class Definition
    {
        public string? definition { get; set; }
        public List<string>? synonyms { get; set; }
        public List<string>? antonyms { get; set; }
        public string? example { get; set; }
    }


}
