using System;
using System.Text;
using System.Text.RegularExpressions;

namespace samo_za_vtornik
{
    class Program
    {
        
        public static bool IBANcheck(string IBAN)
        {
            IBAN = IBAN.ToUpper(); 
            if (String.IsNullOrEmpty(IBAN))
                return false;
            else if (Regex.IsMatch(IBAN, "^[A-Z0-9]"))
            {
                IBAN = IBAN.Replace(" ", String.Empty);
                string bank =
                IBAN.Substring(4, IBAN.Length - 4) + IBAN.Substring(0, 4);
                int ascii = 55;
                StringBuilder sb = new StringBuilder();
                foreach (char c in bank)
                {
                    int v;
                    if (Char.IsLetter(c)) v = c - ascii;
                    else v = int.Parse(c.ToString());
                    sb.Append(v);
                }
                string checkSUM = sb.ToString();
                int checksum = int.Parse(checkSUM.Substring(0, 1));
                for (int i = 1; i < checkSUM.Length; i++)
                {
                    int v = int.Parse(checkSUM.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }
                return checksum == 1;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            string iban1 = "BG80BNBG96611020345678";
            Console.WriteLine(IBANcheck(iban1));
            
        }
    }
}
