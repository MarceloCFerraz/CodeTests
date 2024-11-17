# Counting Sort

**Overview**: Counting sort is a non-comparison-based sorting algorithm that is efficient for sorting integers or objects with integer keys. It works by counting the occurrences of each unique element and then calculating the position of each element in the sorted output.

**Main Logic**:

1. Determine the range of input values (find the minimum and maximum).
2. Create a count array of size equal to the range of input values, initialized to zero.
3. Count each element’s occurrences in the input array and store these counts in the count array.
4. Modify the count array by adding the count of the previous element to get the actual position of each element in the sorted output.
5. Create an output array and place each element in its correct position based on the counts.
6. Copy the sorted elements back to the original array if needed.

**Example** (for an unsorted list `[4, 2, 2, 8, 3, 3, 1]`):

- **Count Occurrences**:
  - Count array for values 1 to 8 might look like: `[0, 1, 2, 2, 1, 0, 0, 1]`
  
- **Modify Count Array**:
  - Adjusted count array: `[0, 1, 3, 5, 6, 6, 6, 7]` (cumulative counts)

- **Build Output Array**:
  - For each element in the original list, place it in the output array using the count array to determine the position.

- **Output**: The final sorted array will be `[1, 2, 2, 3, 3, 4, 8]`.

**Time Complexity**:

- Worst Case: \(O(n + k)\)
- Space Complexity: \(O(k)\) (for the count array)

## Summary

**Counting Sort** is efficient for sorting integers or objects with integer keys in a limited range. It can outperform comparison-based sorts when the range of potential values is small relative to the number of elements.
