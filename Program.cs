using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Testing;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = Fun.Run((dynamic sy) => Math.Pow(sy.x, sy.y));
            Console.WriteLine(f(new { x = 2, y = 2 }));

            var corpus = Fs.Open("test.txt");

            var words = corpus.Split(" ").ToList();
            var wordIdx = words.Distinct().Enumerate().ToList();

            var getIndex = Fun.Run((List<Tuple<int, string>> corpusIndex, string query) => corpusIndex
                .Where(x => x.Item2 == query)
                .Select(y => y.Item1).FirstOrDefault());

            var getWordIndexes = Fun.Run((List<string> corpus, string query) => corpus.Enumerate()
                .Where(x => x.Item2 == query)
                .Select(x => x.Item1).ToList());

            var getNextIndexes = Fun.Run((List<string> corpus, List<Tuple<int, string>> corpusIndexes, List<int> indexes) => {
                var nextIndexes = new List<int>();
                foreach(var idx in indexes) {
                   if(idx < corpus.Count()) {
                        nextIndexes.Add(corpusIndexes
                           .Where(x => x.Item2 == corpus[idx + 1])
                           .Select(x => x.Item1)
                           .FirstOrDefault());
                    }
                }
                return Fun.Yield(nextIndexes);
            });


            var createWordIndexDictionary = Fun.Run((List<string> corpus, List<Tuple<int, string>> corpusIndexes) => {
                var dict = new List<Tuple<int, int>>();
                foreach((var idx, var word) in corpusIndexes) {
                    foreach(var nextIdx in getNextIndexes(corpus, corpusIndexes, getWordIndexes(corpus, word)) {
                        dict.Add(Tuple.Create<int, int>(idx, nextIdx));
                    }
                }
                return dict;
            });
            var dict = createWordIndexDictionary(words, wordIdx);
            
        }
    }
}
