using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasr11_835
{
    class Cryptographer
    {
        /// <summary>
        /// Шифрует русское слово с сдвигом
        /// </summary>
        /// <param name="line">Строка, которую необходимо зашифровать</param>
        /// <param name="shift">Сдвиг на количество букв</param>
        /// <returns></returns>
        public static string Encrypt(string line, int shift)
        {
            line = ChangeExLetters(line);   //Заменяем Ё на Е
            char startRussian = (char)1040;
            char endRussian = (char)1103;
            char[] symbols = line.ToArray();

            for(int i=0; i<symbols.Length; i++)
            {
                if (symbols[i] >= startRussian && symbols[i] <= endRussian)
                    symbols[i] = MoveRussian(symbols[i], shift);
            }
            line = new string(symbols);

            return line;
        }

        /// <summary>
        /// Расшифровавыет зашифрованную строку
        /// </summary>
        /// <param name="line">Зашифрованная строка</param>
        /// <param name="shift">Сдвиг, с которым было зашифровано слово</param>
        /// <returns></returns>
        public static string Decrypt(string line, int shift)
        {
            return Encrypt(line, -shift);
        }

        private static string ChangeExLetters(string line)
        {
            line = line.Replace('Ё', 'Е');
            line = line.Replace('ё', 'е');

            return line;
        }

        private static char MoveRussian(char symbol, int shift)
        {
            int sizeLanguage = 32;
            char endUpperRussian = (char)1071;
            char startRussian = (char)1040;
            char endRussian = (char)1103;

            if (symbol < startRussian || symbol > endRussian)
                throw new ArgumentException("На вход должен подаваться символ русского алфавита, без Ё");

            bool Upper = true;
            if (symbol > endUpperRussian)
                Upper = false;
            else { symbol = (char)(symbol + (char)sizeLanguage); }

            shift = shift % sizeLanguage;   //Находим реальный сдвиг
            int newPosition = (int)symbol + shift;
            if (newPosition > endRussian)
                newPosition -= sizeLanguage;
            else if (newPosition <= endUpperRussian)
                newPosition += sizeLanguage;

            symbol = (char)newPosition;

            if (Upper)
                symbol = (char)(symbol - (char)sizeLanguage);

            return symbol;
        }
    }
}
