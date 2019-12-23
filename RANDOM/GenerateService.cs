using System;

namespace RANDOM
{
    public class GenerateService : IGenerateService
    {
        private readonly Random _rd = new Random();

        public string Symbols { get; private set; }
        public int Length { get; private set; }

        public GenerateService(string strSymbols, int symbolsLength)
        {
            if (string.IsNullOrWhiteSpace(strSymbols))
            {
                throw new ArgumentNullException(nameof(strSymbols));
            }

            if (symbolsLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(symbolsLength));
            }

            Symbols = strSymbols;
            Length = symbolsLength;
        }

        private string Generate(string symbols, int length)
        {
            var chars = new char[length];

            for (var i = 0; i < length; i++)
            {
                chars[i] = symbols[_rd.Next(0, symbols.Length)];
            }

            return new string(chars);
        }

        #region Implementation of IGenerateService

        public string GenerateCode()
        {
            return Generate(Symbols, Length);
        }

        #endregion
    }
}
