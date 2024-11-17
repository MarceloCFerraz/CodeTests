# Bubble Sort

**Overview**: Bubble sort is a simple comparison-based sorting algorithm. It repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order. The process is repeated until no swaps are needed, indicating that the list is sorted.

**Main Logic**:

1. Start from the beginning of the array.
2. Compare the current element with the next element.
3. If the current element is greater than the next element, swap them.
4. Move to the next element and repeat the comparison until the end of the array is reached.
5. After each full pass through the array, the largest unsorted element will have bubbled up to its correct position.
6. Repeat the process for the rest of the array (excluding the last sorted elements) until no swaps are needed.

**Example** (for an unsorted list `[5, 3, 8, 4, 2]`):

- **First Pass**:
  - Compare 5 and 3 → swap → `[3, 5, 8, 4, 2]`
  - Compare 5 and 8 → no swap → `[3, 5, 8, 4, 2]`
  - Compare 8 and 4 → swap → `[3, 5, 4, 8, 2]`
  - Compare 8 and 2 → swap → `[3, 5, 4, 2, 8]`
  
- **Second Pass**:
  - Compare 3 and 5 → no swap → `[3, 5, 4, 2, 8]`
  - Compare 5 and 4 → swap → `[3, 4, 5, 2, 8]`
  - Compare 5 and 2 → swap → `[3, 4, 2, 5, 8]`
  
- **Third Pass**:
  - Continue until the list is sorted.

**Time Complexity**:

- Worst Case: \(O(n^2)\)
- Space Complexity: \(O(1)\) (in-place sort)

## Summary

**Bubble Sort** is easy to understand and implement but is inefficient for large datasets due to its \(O(n^2)\) complexity. It’s mainly educational and rarely used in practice for sorting.
