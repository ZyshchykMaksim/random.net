using System;
using System.Configuration;

namespace RANDOM
{
    public class GenerateService : IGenerateService
    {
        private readonly Random _rd = new Random();

        public string PasswordSymbols { get; private set; }
        public int PasswordLength { get; private set; }
        public string RegisterCodeSymbols { get; private set; }
        public int RegisterCodeLength { get; private set; }

        public GenerateService()
        {
            GenerateSettings section = (GenerateSettings)ConfigurationManager.GetSection("generateSettings");
            if (section != null)
            {
                PasswordSymbols = String.IsNullOrWhiteSpace(section.Password.Symbols) ||
                                  section.Password.Symbols.Length <= 1
                    ? GenerateSettings.Symbols
                    : section.Password.Symbols;
                RegisterCodeSymbols = String.IsNullOrWhiteSpace(section.RegisterCode.Symbols) ||
                                 section.RegisterCode.Symbols.Length <= 1
                   ? GenerateSettings.Symbols
                   : section.RegisterCode.Symbols;

                PasswordLength = section.Password.Length < GenerateSettings.MinLength ? GenerateSettings.Length : section.Password.Length;
                RegisterCodeLength = section.RegisterCode.CodeLength < GenerateSettings.MinLength ? GenerateSettings.Length : section.RegisterCode.CodeLength;
            }
        }

        public string GenerateRegisterCode()
        {
            return Generate(RegisterCodeSymbols, RegisterCodeLength);
        }

        public string GeneratePassword()
        {
            return Generate(PasswordSymbols, PasswordLength);
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
    }
}
