# Sherlock and Anagrams

### Scenario
Two strings are anagrams of each other if the letters of one string can be rearranged to form the other string. Given a string, find the number of pairs of substrings of the string that are anagrams of each other.

For example s, mom, the list of all anagrammatic pairs is [m,m], [mo, om] at positions [[0], [2]], [[0,1], [1,2]] respectively.

### Note
*Made an unique key for Dictionary by rearranging substring and sum up for paired case
*Sum up process is conducted under (Sigma n) - 1, which is equal to {(n * (n + 1)) / 2} - 1