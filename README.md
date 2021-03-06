# Leetcode Contest
Leetcode monthly contest solution attempts 

## September 2021 
### [Week 2](https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/637/week-2-september-8th-september-14th/)
#### September 12
I attempted to build a test rig to simulate cases locally and see if I could get the correct answer in time. 
solution contains two classes:
* Graph: a class that represents a graph
* Node: a class that represents a node in the graph

Given input from test case, I will create a list of nodes, then will create a graph with first node as the root.
then given list of edges, I will create the relationships between nodes, inserting nodes in between as per 3rd number in edges.

I am somehow tempted to replace nodes in between with a scalar value representing weight of edge.

##### Journal 
* `14:47` so far I passed test cases 1 though 13, but case 14 is giving a lower number than expected; 41 instead of 43.
* `15:09` I decided to switch to weighted edge soltion, and placed it in Sol2 namespace.
* `18:12` Sol2 seem more elegant, I managed to fix case 14, but I broke 1 and 2.
* `18:29` I fixed 1 and 3, and broke the rest
* `21:00` I gave up. will work on tomorrow's problem.

#### September 13
problem was super easy, done in first attempt 

#### September 14
Reverse only letters
approach:
* define a stack of characters `stack`
* iterate through the input string `s` reading characters `c`
* if the character `c` is a letter, push it to the stack `stack`
* define an emtpy string `result`
* iterate once again through the input string `s` reading characters `c`
* if the character `c` read from input string `s` is a letter, pop it from the stack `stack` into the result string `result`
* otherwise, append the character `c` to the result string `result`

solution passed all test cases

### [Week 3](https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/)
#### September 15
#### September 16
#### September 17
## Reflection 
In addition to helping me to understand how to use data structures and algorithms, these problems also gave me a good reason to follow _Test Driven Development_ approach.

# [Problems](https://leetcode.com/problemset/all) 
I also started working on general problems from leetcode in folder `problems` and each problem has its own folder.
I will try to be as patient as possible, and try to solve each problem no matter how easy it is.
