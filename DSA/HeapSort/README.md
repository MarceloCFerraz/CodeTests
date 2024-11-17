# Heap Sort

**Overview**: Heap Sort is a comparison-based sorting algorithm that uses a binary heap data structure to sort elements. It takes advantage of the properties of heaps to create a sorted array. Heap Sort is particularly efficient for large datasets and has a time complexity of \(O(n \log n)\).

## Main Logic

1. **Build a Max Heap**:
   - Convert the input array into a max heap. In a max heap, for any given node \(i\), the value of \(i\) is greater than or equal to the values of its children. This property allows the largest element to be at the root of the heap.
   - This can be done by iterating from the last non-leaf node down to the root and applying the heapify process.

2. **Sort the Array**:
   - Extract the maximum element (the root of the heap) and place it at the end of the array. This operation reduces the heap size by one.
   - Restore the heap property by calling the heapify function on the root of the heap.
   - Repeat the extraction and heapify process until all elements are sorted.

## Example

Let’s sort the array `[4, 10, 3, 5, 1]` using Heap Sort.

1. **Build a Max Heap**:
   - Start with the initial array: `[4, 10, 3, 5, 1]`
   - The last non-leaf node is at index \(1\) (which is `10`), and the heapification process will ensure that all parent nodes maintain the max heap property:
     - The array becomes: `[10, 5, 3, 4, 1]` (now a valid max heap).

2. **Sort the Array**:
   - Swap the maximum element (the root `10`) with the last element (`1`):
     - The array looks like: `[1, 5, 3, 4, 10]`
   - Reduce the heap size and heapify the root:
     - After heapifying, it becomes: `[5, 4, 3, 1, 10]`
   - Repeat the process:
     - Swap `5` with `1`: `[1, 4, 3, 5, 10]`
     - Heapify: `[4, 1, 3, 5, 10]`
     - Swap `4` with `1`: `[1, 3, 4, 5, 10]`
     - Heapify: `[3, 1, 4, 5, 10]`
     - Finally, swap `3` with `1`: `[1, 3, 4, 5, 10]`

3. **Final Sorted Array**: The process continues until the array is fully sorted, resulting in `[1, 3, 4, 5, 10]`.

## Time Complexity

- **Best Case**: \(O(n \log n)\)
- **Average Case**: \(O(n \log n)\)
- **Worst Case**: \(O(n \log n)\)
- **Space Complexity**: \(O(1)\) (in-place sort, requires no additional storage)

## Characteristics

- **In-Place**: Heap Sort does not require additional arrays and sorts the elements in the same array, making it space-efficient.
- **Not Stable**: Heap Sort does not maintain the relative order of equal elements, so it is not considered a stable sort.
- **Performance**: While it has a good worst-case time complexity, in practice, it can be slower than Quick Sort due to more overhead with heap operations and the cache efficiency of Quick Sort.

## Conclusion

Heap Sort is a robust sorting algorithm that is efficient, particularly for large datasets, and is based on the properties of binary heaps. Its in-place characteristic makes it a useful choice when memory usage is a concern.
