# Count Triplets

### Scenario
You are given an array and you need to find number of tripets of indices (i, j, k) such that the elements at those indices are in geometric progression for a given common ratio r and i < j < k.

For example, arr[1, 4, 16, 64]. If r = 4, we have [1, 4, 16]  and [4, 16, 64]  at indices (0, 1, 2)  and (1, 2, 3).

Function Description

Complete the countTriplets function in the editor below. It should return the number of triplets forming a geometric progression for a given r as an integer.

### Note
*By using two maps, for a count of numbers in the array and for a count of triplets, counting can be conducted without any sorting process
*Consider that the number from foreach can be used as a third position of a triplet