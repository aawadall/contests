# [Sept 18 - Expression Add Operators](https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3979/)

## Problem Statement
Given a string `num` that contains only digits and an integer `target`, return all possibilities to add the binary operators `'+'`, `'-'`, or `'*'` between the digits of `num` so that the resultant expression evaluates to the `target` value.

## Discussion
Given 1 to 10 numeric digits, we need to find combinations of operators and number concatenation to get the target value.

*Question*: do we need to preserve the order of the operands?
*Question*: what are the precedence rules?

### Possible Operations
* `+`: addition
* `-`: subtraction
* `*`: multiplication
* concatenation

### Approach 1
what if we define a binary tree of possible operations/operands? and calculate it using DFS/post-order traversal?

How complex will that solution be?

binary operations requires two operands; i.e. we will have a maximum of 2^n-1 possible combinations. i.e. our solution will be O(2^n) yikes!

let us try this solution initially, then look for ways to short-circuit the search.

given the following assumptions:
* operators are applied to pairs of operands
* digits are only leaf nodes

we can conclude the height of the tree to be O(log(n))

### Approach 2 
what if we define a flat expression in a 2n-1 array? then try permutations of operations in odd indices of expression array?
