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
            // Add your code here.

            int loc_mul = equation.IndexOf("*");
            int loc_equal = equation.IndexOf("=");

            string temp_A = equation.Substring(0, loc_mul);
            string temp_B = equation.Substring(loc_mul + 1, loc_equal - loc_mul - 1);
            string temp_C = equation.Substring(loc_equal + 1);


            if (temp_A.Contains("?"))
            {
                string correct_ans = decimal.Divide(Int32.Parse(temp_C), Int32.Parse(temp_B)).ToString();


                int loc_ques = temp_A.IndexOf("?");

                if (correct_ans.Substring(0, loc_ques).Equals(temp_A.Substring(0, loc_ques)) && correct_ans.Substring(loc_ques + 1).Equals(temp_A.Substring(loc_ques + 1)))
                {

                    return (int)Char.GetNumericValue(correct_ans[loc_ques]);
                }
                else
                { return -1; }

            }
            else if (temp_B.Contains("?"))
            {

                string correct_ans = decimal.Divide(Int32.Parse(temp_C), Int32.Parse(temp_A)).ToString();
                Console.WriteLine(correct_ans);
                int loc_ques = temp_B.IndexOf("?");

                if (correct_ans.Substring(0, loc_ques).Equals(temp_B.Substring(0, loc_ques)) && correct_ans.Substring(loc_ques + 1).Equals(temp_B.Substring(loc_ques + 1)))
                {
                    return (int)Char.GetNumericValue(correct_ans[loc_ques]);
                }
                else
                { return -1; }

            }
            else
            {

                string correct_ans = (Int32.Parse(temp_A) * Int32.Parse(temp_B)).ToString();

                int loc_ques = temp_C.IndexOf("?");

                if (correct_ans.Substring(0, loc_ques).Equals(temp_C.Substring(0, loc_ques)) && correct_ans.Substring(loc_ques + 1).Equals(temp_C.Substring(loc_ques + 1)))
                {

                    return (int)Char.GetNumericValue(correct_ans[loc_ques]);
                }
                else
                { return -1; }
            }

            throw new NotImplementedException();
        }
    }
}
