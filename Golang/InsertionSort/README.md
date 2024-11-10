# Insertion Sort Overview

**Insertion Sort** is a simple, comparison-based sorting algorithm that builds a sorted array one element at a time. It is efficient for small datasets and works well with partially sorted data.

## How Insertion Sort Works

1. **Initial Setup**:
   - Start with the second element of the array (the first element is considered sorted).

2. **Outer Loop**:
   - Iterate through each element in the array starting from the second element.

3. **Inner Loop**:
   - For each element, compare it with the elements in the sorted portion (to its left).
   - Shift all larger elements in the sorted portion one position to the right to make space for the current element.

4. **Insert**:
   - Once the correct position is found (where the current element is greater than or equal to the left element), insert the current element into that position.

5. **Repeat**:
   - Continue the process until the entire array is sorted.

## Example of Insertion Sort

Let’s sort the array `[5, 2, 9, 1, 5, 6]`:

1. **Pass 1**:
   - Start with key = 2 (the second element).
   - Since `2 < 5`, shift 5 to the right.
   - The array looks like this after the shift: `[5, 5, 9, 1, 5, 6]`.

1. Insert the Key (2) into the first position:
   - Resulting array: `[2, 5, 9, 1, 5, 6]`

1. **Pass 2**:
   - Current element is `9`. It is already in the correct position.
   - Result: `[2, 5, 9, 1, 5, 6]`

1. **Pass 3**:
   - Current element is `1`. Compare with `9`, `5`, and `2`. Shift all three to the right.
   - Insert `1` at the first position.
   - Result: `[1, 2, 5, 9, 5, 6]`

1. **Pass 4**:
   - Current element is `5`. Compare with `9`. Shift `9` to the right.
   - Insert `5` before `9`.
   - Result: `[1, 2, 5, 5, 9, 6]`

1. **Pass 5**:
   - Current element is `6`. Compare with `9`. Shift `9` to the right.
   - Insert `6` before `9`.
   - Result: `[1, 2, 5, 5, 6, 9]`

## Time Complexity

- **Best Case**: \(O(n)\)
  - This occurs when the array is already sorted.
  
- **Average Case**: \(O(n^2)\)

- **Worst Case**: \(O(n^2)\)
  - This occurs when the array is sorted in reverse order.

## Space Complexity

- **Space Complexity**: \(O(1)\)
  - Insertion Sort is an in-place sorting algorithm, meaning it does not require additional storage proportional to the size of the input array.

## Characteristics

- **Stable**: Insertion Sort is a stable sorting algorithm, meaning it maintains the relative order of equal elements.
- **Adaptive**: It performs well on partially sorted data, making it efficient for small or nearly sorted datasets.
- **Simple to Implement**: Its straightforward approach makes it easy to understand and implement.

## Conclusion

Insertion Sort is an efficient sorting algorithm for small datasets and is particularly useful when the data is partially sorted. Its in-place and stable characteristics make it a good choice for certain applications.
