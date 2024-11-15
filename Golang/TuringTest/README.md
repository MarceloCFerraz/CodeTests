# Turing Test

You are provided with two arrays, `arr1` and `arr2` having integer values.

From `arr1`, exactly two elements have been removed, and all remaining elements have been either increased or decreased by the same integer value, denoted by `y`.

As a result, `arr1` becomes identical to `arr2`. Two arrays are considered identical if they contain the same elements with the same frequency.

Your task is to find the ***SMALLEST POSSIBLE*** integer `y` that makes the two arrays identical.

## Example 1

Input:

- arr1 = `[5, 30, 25, 20, 15]`,
- arr2 = `[22, 18, 28]`

Output: `-3`

### Explanation

After removing the elements at indices 1 (`30`) and 4 (`15`) and subtracting `3`, arr1 becomes `[22, 18, 28]`.

## Example 2

Input:

- arr1 = `[6, 9, 9, 6]`
- arr2 = `[12, 12]`

Output: `3`

### Explanation

After removing the elements at indices [0, 3] and adding 3, arr1 becomes [12, 12].

## Constraints

- `3 <= arr1.length <= 200`
- `arr2.length == arr1.length - 2`
- `0 <= arr1[i], arr2[i] <= 1000`

The test cases are generated in a way that there is an integer x such that arr1 can become equal to arr2 by removing two elements and adding x to each element of nums1.
