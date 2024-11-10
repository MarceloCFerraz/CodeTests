# Zig Zag Sequence

In this challenge, the task is to debug the existing code to successfully execute all provided test files.

Given an array of `n` distinct integers, transform the array into a zig zag sequence by permuting the array elements. A sequence will be called a zig zag sequence if the first `k` elements in the sequence are in increasing order and the last `k` elements are in decreasing order, where `k = (n + 1) / 2`. You need to find the lexicographically smallest zig zag sequence of the given array.

> `Lexicographically smallest sequence` is just a way to make you lose a lot of time trying to guess what the fuck they want and also a way to guide you to a stupid first implementation. For this stupid question simply order the fucking array ascending first, then get the last k elements and put them back descending. THAT'S F*ING IT!

## Example

`a = [2, 3, 5, 1, 4]`

Now if we permute the array as `[1, 4, 5, 3, 2]`, the result is a zig zag sequence.

> Again another try to mislead you. If `a = [2, 3, 5, 1, 4]`, response should be `[1, 2, 5, 4, 3]`!

Debug the given function `findZigZagSequence` to return the appropriate zig zag sequence for the given input array.

> There's no such thing. I coded this shit from scratch and the f*king platform don't even accept my answer, even if it's correct.

**Note**: You can modify at most three lines in the given code. You cannot add or remove lines of code.

To restore the original code, click on the icon to the right of the language selector.

## Input Format

The first line contains  the number of test cases. The first line of each test case contains an integer `n`, denoting the number of array elements. The next line of the test case contains `n` elements of array `a`.

## Constraints

- `1 <= t <= 20`
- `1 <= n <= 10000 (n is always odd)`
- `1 <= ai <= 10^9`

## Output Format

For each test cases, print the elements of the transformed zig zag sequence in a single line.
