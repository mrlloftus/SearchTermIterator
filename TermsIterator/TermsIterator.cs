using System;
using System.Collections.Generic;
using System.Linq;

namespace TermsIterator
{
    public class SearchTermIterator
    {
        private string _input;
        private int _termIndex;
        private List<string> _parsedInput;
        private List<string> _result;
        private List<string> _exhaustedTerms;
        private string _currentTerm;
        private bool _inputFault;

        public static SearchTermIterator GetInstance(string input)
        {
            return new SearchTermIterator(input);
        }

        private SearchTermIterator(string input)
        {
            if (input == null)
            {
                _inputFault = true;
                return;
            }

            _input = new string(input.Where(c => !char.IsPunctuation(c)).ToArray()).Trim();
            Initialize();
        }

        private void Initialize()
        {
            EnumerateInput();
            _termIndex = 0;
        }

        private void EnumerateInput()
        {
            _parsedInput = _input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToList();

            _result = new List<string>();

            var startIndex = 0;
            var chunkSize = _parsedInput.Count - 1;

            while (chunkSize > 1)
            {
                while (ChunksRemainBeforeEndOfInput(startIndex, chunkSize))
                {
                    string chunck = FindChunk(startIndex, chunkSize);
                    if (chunck.Length > 0)
                        _result.Add(chunck.Trim());
                    startIndex++;
                }
                startIndex = 0;
                chunkSize--;
            }

            _result.AddRange(_parsedInput.ToHashSet());
            if (_parsedInput.Count > 1)
                _result.Insert(0, _parsedInput.ToDelimitedString(' '));
        }

        private string FindChunk(int startIndex, int chunkSize)
        {
            var result = string.Empty;
            for (var i = startIndex; i < startIndex + chunkSize; i++)
            {
                result += _parsedInput[i] + " ";
            }
            return result;
        }

        private bool ChunksRemainBeforeEndOfInput(int startIndex, int chunkSize)
        {
            return startIndex <= _parsedInput.Count - chunkSize;
        }

        public bool HasNext()
        {
            if (_inputFault)
                return false;

            return _termIndex < _result.Count;
        }

        public string Next()
        {
            LazyzLoadExhaustedTerms();

            _currentTerm = FindNextUnusedTerm();

            _exhaustedTerms.Add(_currentTerm);

            _termIndex++;
            return _currentTerm;
        }

        private void LazyzLoadExhaustedTerms()
        {
            if (_exhaustedTerms == null)
                _exhaustedTerms = new List<string>();
        }

        private string FindNextUnusedTerm()
        {
            while (_exhaustedTerms.Contains(_result[_termIndex]))
            {
                _termIndex++;
            }
            return _result[_termIndex].Trim();
        }

        public void ReportHit()
        {
            if (_currentTerm.Split(' ').Length.Equals(1)) return;

            RemoveHitFromInput();
            Initialize();
        }

        private void RemoveHitFromInput()
        {
            _input = _input.Replace(_currentTerm, string.Empty).Trim();
            _input = _input.Replace("  ", " ");
        }
    }
}
