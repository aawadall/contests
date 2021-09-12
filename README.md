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
`14:47 PM` so far I passed test cases 1 though 13, but case 14 is giving a lower number than expected; 41 instead of 43.