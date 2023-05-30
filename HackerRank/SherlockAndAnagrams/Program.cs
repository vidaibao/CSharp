namespace SherlockAndAnagrams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "mom";
            Console.WriteLine(SherlockAndAnagrams(s));
        }




        public static int SherlockAndAnagrams(string s)
        {

            int count = 0;
            Dictionary<string, int> frequencyMap = new Dictionary<string, int>();

            // Lặp qua các độ dài của chuỗi con
            for (int len = 1; len < s.Length; len++)
            {
                // Lặp qua tất cả các vị trí trong chuỗi
                for (int i = 0; i <= s.Length - len; i++)
                {
                    string sub = s.Substring(i, len);
                    string sortedSub = SortString(sub);

                    // Tăng tần suất của chuỗi con đã sắp xếp
                    if (frequencyMap.ContainsKey(sortedSub))
                    {
                        frequencyMap[sortedSub]++;
                    }
                    else
                    {
                        frequencyMap[sortedSub] = 1;
                    }
                }

                // Đếm số cặp anagram từ tần suất
                foreach (int freq in frequencyMap.Values)
                {
                    count += freq * (freq - 1) / 2;
                }

                frequencyMap.Clear();
            }

            return count;
        }


        static string SortString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Sort(arr);
            return new string(arr);
        }

    }
}




/*
 * Two strings are anagrams of each other if the letters of one string can be
 * rearranged to form the other string. Given a string, find the number of pairs
 * of substrings of the string that are anagrams of each other.

Example
s = mom


The list of all anagrammatic pairs is [m,m], [mo,om] 
at positions [[0],[2]], [[0,1],[1,2]] respectively.

Function Description

Complete the function sherlockAndAnagrams in the editor below.

sherlockAndAnagrams has the following parameter(s):

string s: a string
Returns

int: the number of unordered anagrammatic pairs of substrings in 

Input Format

The first line contains an integer q, the number of queries.
Each of the next  lines contains a string  to analyze.

Constraints
1 <= q <= 10
2 <= length of s <= 100

s contains only lowercase letters in the range ascii[a-z].







***************************************************************---
*
*Phân tích văn bản: Thuật toán này có thể được sử dụng để phân tích văn bản, như kiểm tra xem có các cặp từ là các anagram của nhau trong một đoạn văn bản. Điều này có thể hữu ích trong các ứng dụng tìm kiếm và so sánh văn bản, ví dụ như kiểm tra tính duy nhất của từ khóa trong các tài liệu hoặc phân loại các văn bản dựa trên tần suất xuất hiện của các cặp anagram.

Kiểm tra tính duy nhất của mã số hoặc chuỗi: Trong các ứng dụng mã hóa, thuật toán này có thể được sử dụng để kiểm tra tính duy nhất của mã số hoặc chuỗi. Ví dụ, bạn có thể sử dụng nó để kiểm tra xem có hai mã số hoặc chuỗi giống nhau trong một danh sách hay không, đồng thời cung cấp thông tin về số lượng các cặp anagram trong danh sách.

Xử lý ngôn ngữ tự nhiên: Trong lĩnh vực xử lý ngôn ngữ tự nhiên, thuật toán này có thể được sử dụng để phân tích và so sánh các từ hoặc cụm từ. Ví dụ, trong việc xây dựng công cụ dịch thuật, bạn có thể sử dụng thuật toán này để tìm các từ hoặc cụm từ trong ngôn ngữ đích có cùng tần suất xuất hiện nhưng vị trí khác nhau so với ngôn ngữ nguồn.

Phân loại và nhận dạng: Thuật toán này có thể được áp dụng trong các bài toán phân loại và nhận dạng, ví dụ như nhận dạng chữ ký, nhận dạng tiếng nói hoặc nhận dạng hình ảnh. Bằng cách so sánh các cặp chuỗi có cùng tần suất xuất hiện, thuật toán có thể giúp xác định các mẫu hoặc ký tự tương tự trong các dữ liệu đầu vào.


Phân tích DNA và genetik: Trong lĩnh vực genetik và sinh học phân tử, thuật toán này có thể được sử dụng để tìm kiếm các chuỗi gen có cấu trúc tương tự nhau trong các dữ liệu DNA. Bằng cách tìm các cặp anagram, thuật toán có thể giúp xác định sự tương đồng genetik và quan hệ họ hàng giữa các loài.

Phân tích dữ liệu dạng chuỗi: Trong các ứng dụng phân tích dữ liệu, thuật toán này có thể được sử dụng để xác định các cụm dữ liệu tương đồng dựa trên tần suất xuất hiện của các chuỗi ký tự. Ví dụ, trong phân tích văn bản, thuật toán có thể giúp tìm ra các cụm từ hay cụm từ dạng phổ biến trong tập dữ liệu.

Kiểm tra tính đối xứng của chuỗi: Thuật toán "Sherlock and Anagrams" cũng có thể được sử dụng để kiểm tra tính đối xứng của một chuỗi. Nếu số lượng cặp anagram trong chuỗi ban đầu lớn hơn 0, điều đó có nghĩa là chuỗi không đối xứng. Ví dụ, trong các bài toán liên quan đến kiểm tra tính đối xứng của từ hoặc chuỗi, thuật toán này có thể được áp dụng để xác định tính đối xứng của chúng.

Phân loại dữ liệu và nhận dạng biểu đồ: Trong các ứng dụng phân loại và nhận dạng dữ liệu, thuật toán này có thể được sử dụng để xác định sự tương đồng giữa các biểu đồ hoặc cấu trúc dữ liệu. Bằng cách tìm các cặp anagram, thuật toán có thể giúp phân loại và nhận dạng các biểu đồ có cùng mẫu hoặc cấu trúc tương tự.
 */