namespace PalindromeIndex
{
    internal class Program
    {

        /*
         *  Given a string of lowercase letters in the range ascii[a-z], 
         *  determine a character that can be removed to make the string a palindrome. 
         *  There may be more than one solution, but any will do. 
         *  For example, if your string is "bcbc", you can either remove 'b' at index 0 or 'c' 
         *  at index 3 . If the word is already a palindrome or there is no solution, return -1.
         *  Otherwise, return the index of a character to remove.
         *  1 <= |s| <= 10^5 + 5
         */
        static void Main(string[] args)
        {
            string s = "aaa";// "aabcbcaa" 2;  // "blaalb" -1 "abcdcb" 0  "bcdcba" 3
            Console.WriteLine($"{s}\t{palindromeIndex(s)}");
        }




        static bool isPalindrome( string s)
        {
            return s.Equals(string.Join("", s.ToArray().Reverse()));
        }

        public static int palindromeIndex(string s)
        {
            if (isPalindrome(s))
                return -1;

            int len = s.Length;

            for (int i = 0; i < len / 2; i++)
            {
                if (s[i] != s[len - 1 - i])
                {
                    if (isPalindrome(s.Remove(i, 1)))
                    {
                        return i;
                    }
                    else if (isPalindrome(s.Remove(len - 1 - i, 1)))
                    {
                        return len - 1 - i;
                    }
                }
            }
            return -1;
        }

    }
}