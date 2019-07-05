using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            int loc_mul = equation.IndexOf("*");
            int loc_equal = equation.IndexOf("=");
            string[] temp = equation.Split('*', '=');
            //string temp_A = equation.Substring(0, loc_mul);
            //string temp_B = equation.Substring(loc_mul + 1, loc_equal - loc_mul - 1);
            //string temp_C = equation.Substring(loc_equal + 1);

            if (temp[0].Contains("?"))
            {
                string correct_ans = decimal.Divide(Int32.Parse(temp[2]), Int32.Parse(temp[1])).ToString();
                int loc_ques = temp[0].IndexOf("?");
                if (correct_ans.Substring(0, loc_ques).Equals(temp[0].Substring(0, loc_ques)) && correct_ans.Substring(loc_ques + 1).Equals(temp[0].Substring(loc_ques + 1)))
                {
                    return (int)Char.GetNumericValue(correct_ans[loc_ques]);
                }
                else
                { return -1; }

            }
            else if (temp[1].Contains("?"))
            {
                string correct_ans = decimal.Divide(Int32.Parse(temp[2]), Int32.Parse(temp[0])).ToString();
                
                int loc_ques = temp[1].IndexOf("?");
                if (correct_ans.Substring(0, loc_ques).Equals(temp[1].Substring(0, loc_ques)) && correct_ans.Substring(loc_ques + 1).Equals(temp[1].Substring(loc_ques + 1)))
                {
                    return (int)Char.GetNumericValue(correct_ans[loc_ques]);
                }
                else
                { return -1; }
            }
            else
            {
                string correct_ans = (Int32.Parse(temp[0]) * Int32.Parse(temp[1])).ToString();
                int loc_ques = temp[2].IndexOf("?");
                if (correct_ans.Substring(0, loc_ques).Equals(temp[2].Substring(0, loc_ques)) && correct_ans.Substring(loc_ques + 1).Equals(temp[2].Substring(loc_ques + 1)))
                {
                    return (int)Char.GetNumericValue(correct_ans[loc_ques]);
                }
                else
                { return -1; }
            }            
        }
    }
}
