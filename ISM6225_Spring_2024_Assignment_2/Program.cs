using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 142;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        // Initial thought create an arraylist as it is dynamic in size since we don't know how many numbers are missing.
        // We can loop through the length of the given array and check if the number is present in the array or not.
        // If it is not present, we can add it to the arraylist of missing numbers. Then return the arraylist of missing numbers.
        // But a more efficient way is to use a HashSet.
        // first checking if the array is null or empty and returning an empty list
        // What is a hashset? This allows us to store only the unique elements which are present in the given array. Discarding the duplicates
        // After discrading the duplicates, we can loop through the length of the given array and check if the number is present in the hashset or not.
        // If it is not present, we can add it to a LIST of missing numbers.
        // What is a list? A list is dynamic in size and the elements in a list can be accessed using an index.
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // checking if the array is null or empty and returning an empty list
                if (nums == null || nums.Length == 0)
                {
                    return new List<int>(); // Return an empty list if the array is null or empty
                }
                int n = nums.Length;
                // Using a HashSet to track numbers and the missing ones to return
                HashSet<int> numSet = new HashSet<int>(nums);
                // we are creating a list to store the missing numbers
                List<int> missingNum = new List<int>();
                // Looping through the length of the given array.
                for (int i = 1; i <= n; i++)
                {
                    // Checking if the number is present in the hashset or not.
                    if (!numSet.Contains(i))
                    {
                        // If it is not present, we can add it to a LIST of missing numbers.
                        missingNum.Add(i);
                    }
                }
                // Returning the list of missing numbers
                // if there are no missing elements in the given array, it will return an empty list
                return missingNum;
            }
            // IF there are any exceptions, we are throwing the exception
            catch (Exception)
            {
                throw;
            }
        }
        // The time complexity of this solution is O(n) because we are looping through the length of the given array and checking if the number is present in the hashset or not.
        // space complexity is O(n) because we are using a hashset to store the numbers and a list to store the missing numbers.


        // Question 2: Sort Array by Parity
        // Initial Thought Create another array of the same size as the given array and loop through the length of the given array trying to find the even number If it is even, We move it to the next index of the the previous even number and the odd number is sent to the end of the array.
        // creating two arrays increases the time complexity and space complexity. So a two pointer approach would be optimal.
        // We can use two pointers, one starting from the beginning of the array and the other from the end.
        // We can check if the left number is even, we can move to the next number. If the right number is odd, we can move to the previous number. If the left number is odd and the right number is even, we can swap them.
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // checking if the array is null or empty and returning the original array
                if (nums == null || nums.Length == 0)
                {
                    return nums; // Return the original array if it's null or empty
                }

                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    // If the left number is even, we can move to the next number
                    if (nums[left] % 2 == 0)
                    {
                        left++;
                    }
                    // If the right number is odd, we can move to the previous number
                    else if (nums[right] % 2 != 0)
                    {
                        right--;
                    }
                    // If the left number is odd and the right number is even, we can swap them
                    else
                    {
                        // Swap the left and right numbers
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                        left++;
                        right--;
                    }
                }

                // Write your code here
                return nums; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }
        // The time complexity of this solution is O(n) because we are looping through the length of the given array and checking if the number is even or odd.
        // space complexity is O(1) because we are not using any extra space to store the numbers.


        // Question 3: Two Sum
        // Initial Thought Two numbers sums means that if we subtract one of the numbers from the target then the other number should be equal to the target.
        // Then we can check if that is present in the array or not. If it is present, we can return the index of the two numbers.
        // We can use a dictionary to store the numbers and their indices.
        // We then loop through the length of the given array and check if the number is present in the dictionary or not.
        // If it is present, we can return the index of the two numbers.
        // If it is not present, we can add the number to the dictionary and continue.
        // We can also check if the target is less than 0 or not. If it is less than 0, we can return an empty array.
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> newDict = new Dictionary<int, int>();
                for(int i = 0; i < nums.Length; i++)
                {
                    int com = target - nums[i];
                    if (newDict.ContainsKey(com))
                    {
                        return new int[] { newDict[com], i };
                    }
                    newDict[nums[i]] = i;
                }
                Console.WriteLine($"No two sum solution found for target {target}");
                return new int[0]; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }
        // The time complexity of this solution is O(n) because we are looping through the length of the given array and checking if the number is present in the dictionary or not.
        // space complexity is O(n) because we are using a dictionary to store the numbers and their indices.

        // Question 4: Find Maximum Product of Three Numbers
        // Initial Thought We can sort the array and then find the maximum product of the last three numbers which are the largest among them.
        // Checking if the length of the array is less than 3 and returning the error message
        // When it is greater than 3 elements, we first sort the elements in the array
        // If the array contains 2 negative numbers and 1 positive number, then the product of the two negative numbers and the positive number might be greater than the product of the three positive numbers as the resultant number is positive.
        // Then we can check if the product of the last three numbers is greater than the product of the first two numbers and the last number.

        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // checking if the array length is less than 3 or empty and returning the exception message
                if (nums == null || nums.Length < 3)
                {
                    throw new ArgumentException("Array must contain at least three numbers.");
                }
                // Sorting the array
                Array.Sort(nums);
                int n = nums.Length;
                // The maximum product can be either the product of the last three numbers or the product of the first two numbers(if they are both negative) and the last number
                int maxProduct = Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3], nums[0] * nums[1] * nums[n - 1]);
                return maxProduct; // Placeholder
            }
            catch (Exception ex)
            {
                // If there are any exceptions, we are throwing the exception
                Console.WriteLine($"Error: {ex.Message}");
                // Returning a default value
                return int.MinValue;
            }
        }
        // The time complexity of this solution is O(n log n) because we are sorting the array and then finding the maximum product of the last three numbers.
        // space complexity is O(1) because we are not using any extra space to store the numbers.


        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber < 0)
                    throw new ArgumentException("Decimal number must be non-negative.");
                return Convert.ToString(decimalNumber, 2);
            }
            catch (ArgumentException ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                
                return 0; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                return false; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                return 0; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
