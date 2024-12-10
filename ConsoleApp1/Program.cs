using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        // properties, fields
        // collection (Array, ArrayList, Stack, Queue, Dictionary, List, LikedList, HashSet,
        // IEnumberable)
        // Loop ( while,for,do-while,foreach )

        class MobilePhone
        {
            string _brandName; // private backing field
            public string BrandName
            {
                get { return _brandName; }
                set { _brandName = value; }
            }

            public void ShowBrandName()
            {
                Console.WriteLine(_brandName+" "+Color);
                
            }

            public string Color { get; set; } // Automatic Property
        }
        static void Main(string[] args)
        {
            MobilePhone phone = new MobilePhone(); //
            phone.BrandName = "Samsung";
            phone.Color = "Red";
            phone.ShowBrandName();

            // Console.WriteLine("Welcome to Japan");

            int[] nums = {1,2,3,4,5,6,7}; // index (0 to 6) - rank(length) - 7

            int start = 0; // 0
            int end = nums.Length-1; // 6
            HTW: if (start < 7)
            {
                Console.WriteLine(nums[start]); // 1
                start++;
                goto HTW;
            }
            
        }
    }
}
