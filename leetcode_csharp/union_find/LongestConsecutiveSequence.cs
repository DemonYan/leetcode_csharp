namespace leetcode_csharp.union_find
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public int LongestConsecutiveSort(int[] nums)
        {
            if(nums == null || nums.Length == 0)
            {
                return 0;
            }

            Array.Sort(nums);
            var result = 1;
            var caches = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                if (caches.ContainsKey(n))
                {
                    continue;
                }
                caches[n] = 1;
                if (caches.ContainsKey(n - 1))
                {
                    caches[n] = caches[n - 1] + 1;
                    result = Math.Max(result, caches[n]);
                }
            }
            return result;
        }

        public int LongestConsecutive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var result = 1;
            var uniqNums = nums.Distinct().ToHashSet();

            foreach (var n in uniqNums)
            {
                if (uniqNums.Contains(n - 1))
                    continue;
                var tmp = n;
                var count = 1;
                while(uniqNums.Contains(tmp + 1))
                {
                    tmp++;
                    count++;
                }
                result = Math.Max(result, count);
            }
            return result;
        }
    }
}
