# Frequency Queries

### Scenario
You are given q queries. Each query is of the form two integers described below: 
- 1 : x Insert x in your data structure. 
- 2 : y Delete one occurence of y from your data structure, if present. 
- 3 : z Check if any integer is present whose frequency is exactly z. If yes, print 1 else 0.

The queries are given in the form of a 2-D array queries  of size q where queries[i][0] contains the operation, and queries[i][1] contains the data element. 

### Note
*By using two maps, for a count of elements and a count of frequencies, it can search exact frequency by O(n)