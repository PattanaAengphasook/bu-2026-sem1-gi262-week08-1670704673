using System;
using System.Collections.Generic;

namespace Assignment
{
    public class StudentSolution
    {
        // ==========================================
        // Lecture Methods
        // ==========================================

        #region 1. Recursive Factorial
        public int LCT01_RecursiveFactorial(int n)
        {
            return FactorialHelper(n);
        }

        private int FactorialHelper(int n)
        {
            // Base Case: ถ้า n <= 1 ให้คืนค่า 1 (0! และ 1! มีค่าเท่ากับ 1)
            if (n <= 1)
            {
                return 1;
            }

            // Recursive Case: n! = n * (n-1)!
            return n * FactorialHelper(n - 1);
        }
        #endregion

        #region 2. Recursive Fibonacci
        public int LCT02_RecursiveFibonacci(int n)
        {
            return FibonacciHelper(n);
        }

        private int FibonacciHelper(int n)
        {
            // Base Case: ถ้า n <= 1 ให้คืนค่าตัวมันเอง (F(0)=0, F(1)=1)
            if (n <= 1)
            {
                return n;
            }

            // Recursive Case: F(n) = F(n-1) + F(n-2)
            return FibonacciHelper(n - 1) + FibonacciHelper(n - 2);
        }
        #endregion

        #region 3. Recursive Sum of 1 to N
        public int LCT03_RecursiveSumOfOneToN(int n)
        {
            return SumOfOneToNHelper(n);
        }

        private int SumOfOneToNHelper(int n)
        {
            // Base Case: ถ้า n <= 0 ให้คืนค่า 0
            if (n <= 0)
            {
                return 0;
            }

            // Recursive Case: n + Sum(n-1)
            return n + SumOfOneToNHelper(n - 1);
        }
        #endregion

        #region 4. Recursive Sum of Numbers in Array
        public int LCT04_RecursiveSumOfNumbers(int[] numbers)
        {
            // เริ่มต้นการบวกที่ index 0
            return SumOfNumbersHelper(numbers, 0);
        }

        private int SumOfNumbersHelper(int[] arr, int index)
        {
            // Base Case: ถ้า index ชี้เกินความยาวของ array แล้ว ให้คืนค่า 0 (กรณี Array ว่างจะเข้าเคสนี้ทันที)
            if (index >= arr.Length)
            {
                return 0;
            }

            // Recursive Case: ค่าของ array ปัจจุบัน + ผลรวมของ array ตำแหน่งถัดไป
            return arr[index] + SumOfNumbersHelper(arr, index + 1);
        }
        #endregion

        // ==========================================
        // Assignment Methods
        // ==========================================

        #region 5. Recursive Power
        public int ASN01_RecursivePower(int baseNum, int exponent)
        {
            return PowerHelper(baseNum, exponent);
        }

        private int PowerHelper(int baseNum, int exponent)
        {
            // Base Case: เลขอะไรก็ตามยกกำลัง 0 จะได้ 1
            if (exponent == 0)
            {
                return 1;
            }

            // Recursive Case: ฐาน * ค่าของฐานยกกำลังที่ลดลง 1
            return baseNum * PowerHelper(baseNum, exponent - 1);
        }
        #endregion

        #region 6. Is Palindrome
        public bool ASN02_IsPalindrome(string str)
        {
            // ป้องกันกรณี String ว่าง ให้ถือว่าเป็น Palindrome และป้องกัน Error จาก str.Length - 1
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }
            return PalindromeHelper(str, 0, str.Length - 1);
        }

        private bool PalindromeHelper(string str, int start, int end)
        {
            // Base Case 1: ตรวจสอบจนจุดเริ่มต้นมาชนหรือเลยจุดสิ้นสุด แปลว่าตัวอักษรตรงกันหมดแล้ว
            if (start >= end)
            {
                return true;
            }

            // Base Case 2: ถ้าตัวอักษรหน้าและหลังไม่ตรงกัน แปลว่าไม่ใช่ Palindrome
            if (str[start] != str[end])
            {
                return false;
            }

            // Recursive Case: ขยับ start ขึ้น 1 และลด end ลง 1 เพื่อตรวจคู่ถัดไปตรงกลาง
            return PalindromeHelper(str, start + 1, end - 1);
        }
        #endregion

        #region 7. Recursive GCD (Greatest Common Divisor)
        public int ASN03_RecursiveGCD(int a, int b)
        {
            return GCDHelper(a, b);
        }

        private int GCDHelper(int a, int b)
        {
            // Base Case: ตาม Euclidean Algorithm เมื่อตัวหาร (b) เป็น 0 ค่า GCD คือ a
            if (b == 0)
            {
                return a;
            }

            // Recursive Case: หา GCD ของ (b, a เศษ b) ต่อไป
            return GCDHelper(b, a % b);
        }
        #endregion

        #region 8. Recursive Binary Search
        public int ASN04_RecursiveBinarySearch(int[] arr, int target)
        {
            // ป้องกัน array ว่าง
            if (arr == null || arr.Length == 0) return -1;

            return BinarySearchHelper(arr, target, 0, arr.Length - 1);
        }

        private int BinarySearchHelper(int[] arr, int target, int low, int high)
        {
            // Base Case: ถ้าขอบเขตการค้นหาซ้อนทับกัน (หาไม่เจอ) คืนค่า -1
            if (low > high)
            {
                return -1;
            }

            // หาตำแหน่งกึ่งกลาง (ใช้วิธีนี้เพื่อป้องกัน Integer Overflow หาก low และ high มีค่าเยอะมาก)
            int mid = low + (high - low) / 2;

            // Base Case 2: หากเจอเป้าหมาย คืนค่า Index นั้น
            if (arr[mid] == target)
            {
                return mid;
            }

            // Recursive Case:
            // ถ้าค่ากึ่งกลางมากกว่า target แปลว่าข้อมูลเป้าหมายอยู่ฝั่งซ้าย ให้เลื่อน high มาที่ mid - 1
            if (arr[mid] > target)
            {
                return BinarySearchHelper(arr, target, low, mid - 1);
            }
            // ถ้าค่ากึ่งกลางน้อยกว่า target แปลว่าข้อมูลเป้าหมายอยู่ฝั่งขวา ให้เลื่อน low มาที่ mid + 1
            else
            {
                return BinarySearchHelper(arr, target, mid + 1, high);
            }
        }
        #endregion
    }
}