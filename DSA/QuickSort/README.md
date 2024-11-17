# Quick Sort

**Overview**: Quick Sort is a highly efficient and widely used sorting algorithm based on the divide-and-conquer principle. It works by selecting a "pivot" element from the array and partitioning the other elements into two sub-arrays, according to whether they are less than or greater than the pivot. The sub-arrays are then sorted recursively.

## Main Logic

1. **Choose a Pivot**: Select an element from the array to be the pivot. There are various strategies for selecting the pivot (first element, last element, random element, or median).

2. **Partitioning**:
   - Rearrange the array so that all elements with values less than the pivot come before the pivot, and all elements with values greater than the pivot come after it.
   - This process results in the pivot being in its final sorted position.

3. **Recursion**:
   - Recursively apply the same logic to the left and right sub-arrays created by the partitioning step.
   - The base case for the recursion is when the array has one or zero elements, which are inherently sorted.

4. **Combine**: Since the sub-arrays are sorted in place, no additional work is needed to combine them; the entire array becomes sorted.

## Example

Let’s sort the array `[8, 4, 7, 1, 3, 2, 5, 6]` using Quick Sort.

1. **Choose a Pivot**: Let's say we choose `5` as the pivot.

2. **Partitioning**:
   - Start comparing elements to the pivot. After partitioning, the array might look like this: `[4, 1, 3, 2, 5, 7, 8, 6]`.
   - Here, `5` is in its correct position, with all elements less than `5` on the left and greater on the right.

3. **Recursion**:
   - Now apply Quick Sort to the left sub-array `[4, 1, 3, 2]` and the right sub-array `[7, 8, 6]`.

   - For the left sub-array `[4, 1, 3, 2]`, choose `2` as the pivot:
     - After partitioning: `[1, 2, 3, 4]`
   - For the right sub-array `[7, 8, 6]`, choose `6` as the pivot:
     - After partitioning: `[6, 7, 8]`

4. **Combine**: The final sorted array will be `[1, 2, 3, 4, 5, 6, 7, 8]`.

## Time Complexity

- **Best Case**: \(O(n \log n)\) (occurs when the pivot divides the array into two equal halves)
- **Average Case**: \(O(n \log n)\) (typically, with a good pivot selection)
- **Worst Case**: \(O(n^2)\) (occurs when the smallest or largest element is always chosen as the pivot, leading to unbalanced partitions)
- **Space Complexity**: \(O(\log n)\) (due to recursive call stack in the average and best cases; additional space may be used for the partitioning process)

## Characteristics

- **In-Place**: Quick Sort does not require additional storage for the sorted array, making it space-efficient.
- **Not Stable**: It does not maintain the relative order of equal elements (i.e., it is not a stable sort).
- **Performance**: Quick Sort is generally faster in practice compared to other \(O(n \log n)\) algorithms like Merge Sort and Heap Sort due to better cache performance and fewer comparisons on average.

## Conclusion

Quick Sort is one of the most popular sorting algorithms due to its efficiency and simplicity. Its divide-and-conquer strategy, combined with the in-place sorting capability, makes it suitable for a wide range of applications.
